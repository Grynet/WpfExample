#!/bin/bash

# Fail on any error
set -e
trap 'echo "‼️ Script exited unexpectedly at line $LINENO"; exit 1' ERR

# Get the latest version tag (Major.Minor.Patch)
tagExists=1
latestTag=$(git tag --sort=-v:refname | head -n 1)
if [ -z "$latestTag" ]; then
  echo "No tags found. Using default 0.0.0"
  latestTag="0.0.0"
  tagExists=0
elif ! [[ $latestTag =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
  echo "❌ Invalid version format: '$latestTag'"
  exit 1
fi

# Extract major, minor, and patch from the version
IFS='.' read -r major minor patch <<< "${latestTag}"
echo -e "\nLatest tag: $major.$minor.$patch"

# Get the list of commits on master since the last tag (excluding merges)
if [ $tagExists -eq 1 ]; then
  commits=$(git log ${latestTag}..HEAD --reverse --no-merges --pretty=format:"%s")
else
  commits=$(git log --reverse --no-merges --pretty=format:"%s")
fi

echo -e "\nCommits:"

majorChanges=0
minorChanges=0
patchChanges=0

while IFS= read -r commit; do
  
  echo "* $commit"
  # Check if it's a breaking change
  if [[ $commit =~ BREAKING[[:space:]]CHANGE ]]; then
    majorChanges=$((majorChanges + 1))
    minor=0
    patch=0
  # Check if it's a feature commit
  elif [[ $commit =~ ^feat: ]]; then
    minorChanges=$((minorChanges + 1))
    patch=0
  # Check if it's a fix commit
  elif [[ $commit =~ ^fix: ]]; then
    patchChanges=$((patchChanges + 1))
  fi
done <<< "$commits"

major=$((major + majorChanges))
minor=$((minor + minorChanges))
patch=$((patch + patchChanges))

semanticVersion="$major.$minor.$patch"
echo -e "\nSemantic Version: $semanticVersion"
echo "##vso[task.setvariable variable=SemanticVersion;isReadonly=true]$semanticVersion"

echo -e "\n✅ Script completed successfully"