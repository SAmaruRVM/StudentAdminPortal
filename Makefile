push-changes:
	git add --all
	git commit -m "$(commit_message)"
	git push
