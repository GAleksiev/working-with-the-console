# Working with git / GitHub

## git
Git (install it from https://git-scm.com/) is a version control system that tracks changes to files and keeps a history of all the changes.
The files are stored in repositories hosted on servers.
A sample servers hosting git repositories are https://github.com and https://gitlab.com
and a sample repository is https://github.com/GAleksiev/working-with-the-console.

## Repositories
Repository is the container for all the files and branches in the project. In order to start working on some project it is required to `clone` the project repository on the local computer. The clone process downloads all the files of the `default` branch of the repository (in GitHub it is named `main` by default). First you should have a user with access to the repository and then you can clone it on your local computer

To get the URL of the repository you want to clone locally, navigate to GitHub repository, select the `Code` tab then click on the `<> Code` button and copy the HTTPS URL. It looks like `https://github.com/varadero/git-and-github.git` (if you want to try the steps that follow by yourself, create new repository in your GitHub account - initialise it with README.md and use it instead of this sample repository):

<img width="863" alt="image" src="https://user-images.githubusercontent.com/7610713/212541128-04b67edc-ee75-4d12-abdd-39f4a5219989.png">

Once copied, open a console/terminal window and create a temp folder, navigate to it and clone the repository using the following:

```sh
git clone https://github.com/varadero/git-and-github.git
```

This will create a folder (in the current folder) named `git-and-github` and will place all the files of the main branch inside it.

Output:
```
Cloning into 'git-and-github'...
remote: Enumerating objects: 3, done.
remote: Counting objects: 100% (3/3), done.
remote: Total 3 (delta 0), reused 0 (delta 0), pack-reused 0
Receiving objects: 100% (3/3), done.
```

Verify the repository folder was created:

```sh
dir
```
Output:
```
 Volume in drive C has no label.
 Volume Serial Number is 1678-0516

 Directory of C:\dev\tests

2023-01-15  14:43    <DIR>          .
2022-12-31  11:29    <DIR>          ..
2023-01-15  14:43    <DIR>          git-and-github
               0 File(s)              0 bytes
               3 Dir(s)  149,341,278,208 bytes free
```

And navigate to it:

```sh
cd git-and-github
```

Now list all the files (including hidden):

```sh
dir /a
```
Output:
```
2023-01-15  14:43    <DIR>          .
2023-01-15  14:43    <DIR>          ..
2023-01-15  14:43    <DIR>          .git
2023-01-15  14:43                16 README.md
               1 File(s)             16 bytes
               3 Dir(s)  149,339,897,856 bytes free
```

You will notice the `README.md` file is here (the repository was initialised with it when created in GitHub) and a folder `.git` - this is the folder for the cloned repository - git will keep all your local changes and branches into this folder.


## Branches
A simplified explanation of what branch is is a set of files kept together. In the example with the new repository it has one file only (`READM.md`) in the branch named `main` (the default branch name GitHub gives when new repository is created). A repository can have many branches but only one of them is currently active. To check which is the current active branch:

```sh
git branch
```

Output:

```
* main
```

The current branch is `main` (marked with `*` before its name).

The changes to the files are usually made in their own branches and not directly to the default branch (`main` in our case). This is because the changes to the project code can introduce bugs and the changed code must be reviewed before becoming part of the application code. For this purpose often the default branch of the repository is never meant to be changed directly but only by means of `pull requests` (in other git hosts like GitLab it is called `merge request`). The `pull request` is essentially someone asking the maintainers of the `main` branch to put the changes made by him (in a specific branch) into the `main` branch. The pull request contains differences between the `main` branch and the branch that requests `pull` (`merge`) and they are inspected for problems. If the `main` branch maintainers decide that the changes are OK, they can merge the changes to the `main` branch.

This is how it works from the point of view of the developer, that needs to make changes to the code:
- The developer needs to make some changes to the code that is already in the `main` branch
- It switches to the `main` branch locally by using `git checkout <branch-name>`:
```sh
git checkout main
```
Output:
```
Already on 'main'
Your branch is up to date with 'origin/main'.
```
- In our case we are already on `main` branch
- The `git checkout <branch-name>` switches the content of current directory (its files and subdirectories recursively) to be the same as the content in the specified branch (stored in the git's repository folder `.git`). We are switching to the local branch `main`, but the content of the local `main` branch could be older than the content on the remote `main` branch (on GitHub). This can happen if someone made pull request and it was merged after you last pulled the `main` branch from the server. That's why after checking out some local branch, you need to synchronize it's content with the remote branch content by pulling it:
```sh
git pull
```
Output:
```
Already up to date.
```
- In our case our local `main` branch is the same as the one on the remote server - that's why we see `Already up to date.`
- Now create new local branch out of the current branch (we are on `main`) with:
```sh
git checkout -b changes-to-readme
```
Output:
```
Switched to a new branch 'changes-to-readme'
```
- The output says `Switched to a new branch '....'` meaning that we created new branch with name `changes-to-readme` which have the same content with the branch we were while we executed `git checkout -b ...` and this was the `main` branch
- Verify that the current branch is the new branch:
```sh
git branch
```
Output:
```
* changes-to-readme
  main
```
- Notice that we now have 2 branches and our new branch is the current (marked with `*`)
- Now we can start changing the files - in our case open the `README.md` file with any editor and add one more line at the end:
```
# git-and-github
This is a new line
```
- Save the file
- Look at the git status of the current branch:
```sh
git status
```
Output:
```
On branch changes-to-readme
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git restore <file>..." to discard changes in working directory)
        modified:   README.md

no changes added to commit (use "git add" and/or "git commit -a")
```
- The above output shows that there is one `modified` file - `README.md` - the text is in the section `Changes not staged for commit` specifying that this is a change of a local file but it will not yet become part of the branch (commited into the current branch).
- The next step is to add everything we want from the changes to the git's `staging area` (read for the git staging area at https://git-scm.com/about/staging-area) - this is git "local internal" place where the changes are added and become ready for commit to the current branch (of the local repository). Usually (although not mandatory) all the changes are added to the `staging area` with:
```sh
git add .
```
- If there is no error - no output will be shown from the `git add .` command. Now all the changes should be in the git's `staging area` - check the git status again:
```sh
git status
```
Output:
```
On branch changes-to-readme
Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        modified:   README.md
```
- Now the `git status` shows the changes, which will be commited to the branch in the section `Changes to be committed:` and in green color. Now to make the staged changes ("to be committed") part of the branch, we need to make a commit:
```sh
git commit -m "Added new test line in README.md"
```
- The `git commit` commits the staged changes to the branch and assigns a commit message with `-m "<the message text">` - the commit message is mandatory. Every commit also must have information for the user that did the commit. For that reason, if this local repository was not configured who is commiting to it, you will see error like:
```
Author identity unknown

*** Please tell me who you are.

Run

  git config --global user.email "you@example.com"
  git config --global user.name "Your Name"

to set your account's default identity.
Omit --global to set the identity only in this repository.

fatal: unable to auto-detect email address (got '...(none)')
```
- If this happens, you need to configure local repository user and email which will appear in the commit hostory - the message shows a sample command using `--global` flag but we will configure it only for this repository by omitting it - this allows to use different user/email for different repositories that you have on your local computer. Identify yourself to the local git repository with:
```sh
git config user.email "your@email.com"
git config user.name "Test user"
```
- Now if you repeat the commit, it should succeed:
```sh
git commit -m "Added new test line in README.md"
```
Output:
```
[changes-to-readme f807043] Added new test line in README.md
 1 file changed, 2 insertions(+), 1 deletion(-)
```
- At this point all the changes are commited and the status of current branch should be "clean":
```sh
git status
```
Output:
```
On branch changes-to-readme
nothing to commit, working tree clean
```
- Now you have a new local branch that contains the changes you want to become part of the `main` branch. For this, the local branch must be "pushed" to the remote repository:
```sh
git push
```
Output:
```
fatal: The current branch changes-to-readme has no upstream branch.
To push the current branch and set the remote as upstream, use

    git push --set-upstream origin changes-to-readme

To have this happen automatically for branches without a tracking
upstream, see 'push.autoSetupRemote' in 'git help config'.
```
Because this is a new branch not only for the local repository but also for the remote repository (the branch `changes-to-readme` does not exist yet in the remote repository), `git push` fails - we must specify what is the name of the remote branch that must be created - usually the same name as the local branch is used (we are using the suggested command in the error message):
```sh
git push --set-upstream origin changes-to-readme
```
Output:
```
Enumerating objects: 5, done.
Counting objects: 100% (5/5), done.
Writing objects: 100% (3/3), 291 bytes | 291.00 KiB/s, done.
Total 3 (delta 0), reused 0 (delta 0), pack-reused 0
remote:
remote: Create a pull request for 'changes-to-readme' on GitHub by visiting:
remote:      https://github.com/varadero/git-and-github/pull/new/changes-to-readme
remote:
To https://github.com/varadero/git-and-github.git
 * [new branch]      changes-to-readme -> changes-to-readme
branch 'changes-to-readme' set up to track 'origin/changes-to-readme'.
```
- Our local branch is also in the remote repository - check this by opening GitHub repository `Code` tab, refresh and click on the branch drop-down:

<img width="605" alt="image" src="https://user-images.githubusercontent.com/7610713/212546799-fceec758-0ac4-47f6-a434-9f2668f04b41.png">

## Pull requests
Now when our local branch `changes-to-readme` is pushed to the remote repository, we can request the changes to be merged to the `main` branch. For this, select the new branch from the drop-down:

<img width="621" alt="image" src="https://user-images.githubusercontent.com/7610713/212547068-8c7c08bb-e936-4c0a-9ccf-b21c2e4e68de.png">

You will see `This branch is 1 commit ahead of main.` - this means the selected branch has 1 commit more compared to the `main` branch - this is our commit that we just made.

GitHub allows you to immediatelly make pull request for the branch which was just pushed, but in general, pull requests are available when you click on `Pull requests` tab and then `New pull request` button. You will see the following:

<img width="744" alt="image" src="https://user-images.githubusercontent.com/7610713/212547412-0d7c7ce1-1aef-4f7e-b5c0-df37704dab95.png">

The highlighted part shows the base branch to which we want our code to be merged to and the other branch which contains the changes we want to be merged. The "base" branch selection (the left drop-down) in our case must be `main` because we want our changes to be merged to the `main` branch (in general, the "base" branch selection should be the same as the branch from which we locally created our new branch with `git checkout -b <the-new-branch-name>`). The "compare" branch selection in our case must be the branch we pushed - `changes-to-readme`. After selection of the "base" and "compare" branches you should see the changes:

<img width="775" alt="image" src="https://user-images.githubusercontent.com/7610713/212547948-2af6f3cf-2e7c-42a9-b35c-9c767c34118d.png">

The information provided is how many commits are there, how many files are changed and how many people contributed to these changes. In our case 1 commit, 1 file changed from 1 contributor. The commit message is also shown and the highlighted changes below - you can see on the left the content of the `main` branch and on the right - how it will be changed if the pull request is approved and merged.

In our case on the left (the `main` branch content) it says that the line `# git-and-github` will be deleted (because of the minus sign before it) and on the right it says that two lines will be added - the "original" first line and the new line we added manually. The fact that we see the same first line on the left as "deleted" and on the right as "added" is that we changed this line to have a "new line" at the end - this is considered as "remove this line and put the same line in its place but with addition of a new line characters at the end". Depending on the changes made, this "diff" screen could show changes which have "more" or "less" sense but in general, the changes here must be carefully inspected (what will be changed in the `main` branch if the pull request is merged) before making the pull request.

When the changes look OK, click on the `Create pull request` button, then provide a description if needed and click on the yet another `Create pull request` button below:

<img width="851" alt="image" src="https://user-images.githubusercontent.com/7610713/212548622-719ef8d7-9587-431e-b077-60f158b9098d.png">

This is what you will see after creating the pull request:

<img width="858" alt="image" src="https://user-images.githubusercontent.com/7610713/212548758-8f12393e-c7b3-44bf-adef-af605a6aac43.png">

Now the pull request can be inspected by maintainers of the `main` branch and if approved, it will be merged to the "base" branch selection - in out case `main`.

You can now go to `Code` tab and select tha `main` branch and look at the `README.md` content:

<img width="1106" alt="image" src="https://user-images.githubusercontent.com/7610713/212548829-45cf7f7f-308b-4343-b7ae-f8cc0ecb01df.png">

It still has one line only. Now go to `Pull requests` tab, click on the pull request and click on `Files changed` tab:

<img width="778" alt="image" src="https://user-images.githubusercontent.com/7610713/212548920-030ed96a-596a-4922-b81e-7be19fa79fc9.png">

You will see the "base" and "compare" branches and what will be changed if pull request is merged. Now click on `Merge pull request` to merge it to the `main` branch:

<img width="781" alt="image" src="https://user-images.githubusercontent.com/7610713/212549028-45860fb2-49ca-4d36-88c3-3643e63b262e.png">

Now go to `Conversation` tab and verify that there are no conflicts with the "base" branch (merge conflicts are another topic) and click on `Merge pull request` button and then on `Confirm merge`:

<img width="524" alt="image" src="https://user-images.githubusercontent.com/7610713/212549142-029b759c-4c4f-4093-885f-45246ef137b1.png">

Now the changes made in the pull request are merged to the "base" branch (in this pull request the "base" branch was `main`) - go to `Code` tab and open the `README.md` file of the `main` branch to confirm the changes were merged:

<img width="781" alt="image" src="https://user-images.githubusercontent.com/7610713/212549334-8808dc28-911a-4888-82f1-511bad4e4341.png">

## Updating pull requests
Often after a pull request is made there are comments about the code and someone requests to change something. The steps to do this are simple - just switch to the pull request branch on your local computer, do the changes, commit them and push them - then the pull request will be updated.

## .gitignore
When the developer uses IDE to make changes to the code, it often creates its own folders/files in the current directory to server its needs. These files are not part of the project the developer is working on and must be excluded so they are not commited and pushed to the remote repository. For example Visual Studio 2022 creates a folder named `.vs` where it keeps some configuration and also folders `bin` and `obj` when the project is build, Visual Studio Code creates `.vscode` folder for similar purposes etc. These folders can be ignored and never commited by creating a file named `.gitignore` (the name starts with dot) in the root of the folder. Its content describes what must be skipped by git when commits are made (git itself already excludes its own folder `.git` without the need of ignoring it). This is a sample content of `.gitignore` file that can be created in order to avoid commiting the mentioned folders in Visual Studio 2022 and Visual Studio Code:
```
.vs
bin
obj
.vscode
```
If you don't have this file with similar content, you could see these folders as part of the changes git detected and it will offer to commit them - this is how it can look like in Visual Studio 2022 (the "A" at the right of the file names means this file is new/just added to the current folder):

<img width="270" alt="image" src="https://user-images.githubusercontent.com/7610713/212550422-122a1a0e-0bd7-4203-a7fb-153e2dd26919.png">

Which is equivalent of the output of `git status`:
```sh
git status
```
Output:
```
On branch changes-to-readme
Your branch is up to date with 'origin/changes-to-readme'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .vs/

nothing added to commit but untracked files present (use "git add" to track)
```

If `.gitignore` file is created in the root folder with the following content:

<img width="476" alt="image" src="https://user-images.githubusercontent.com/7610713/212550558-802da948-c0fe-4c9e-82ea-46eb24b383ea.png">

The git changes window will not contain any file in the `.vs` folder anymore and the git status (`Git Changes` window) will show only the newly added `.gitignore` file:

<img width="267" alt="image" src="https://user-images.githubusercontent.com/7610713/212550691-e8fe3040-38ed-4d11-b368-c65e002972c0.png">

Which is equivalent of the output of `git status`:

```sh
git status
```
Output:
```
git status
On branch changes-to-readme
Your branch is up to date with 'origin/changes-to-readme'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitignore

nothing added to commit but untracked files present (use "git add" to track)
```

## Using git in Visual Studio 2022
Visual Studio 2022 (and almost all other development IDEs) have support for git. The git commands we used above are available for the developer inside Visual Studio 2022. When you open Visual Studio 2022 project/solution/folder (in our case it is just the folder where we cloned the remote repository `git-and-github`) which is under git source control, you can show the git toolbox by selecting the menu `View - Git Changes`:

<img width="266" alt="image" src="https://user-images.githubusercontent.com/7610713/212549929-5f1f5099-19f9-4239-ac4a-3c1f6f11300f.png">

You will notice a drop-down used to switch between branches (equivalent of `git checkout <branch-name`>), the pull (`git pull` - the second "Arrow down" button) and push (`git push` - the "arrow up" button) buttons, the commit message and button (`git commit -m "Commit message"`) and the list with changes which can be staged (`git add .`).

Let's make some changes - create the `.gitignore` from the previous step and save it. Open the `README.md` file and add new line between the other two so the file looks like:

```
# git-and-github
This is a line between
This is a new line
``` 

Open `Git Changes` - you should see the following:

<img width="258" alt="image" src="https://user-images.githubusercontent.com/7610713/212551013-026664fd-c4e7-48d0-bfbc-79a7b1616da2.png">

Inspect what has been changed by double clicking all the files in `Changes` list.

Since the file `.gitignore` is new (marked as `A` (meaning "Added") on the right in the `Changes` list), double clicking on it will not show any difference, because there is no previous version of this file - it will just show its content.

The file `README.md` was in the branch before and is considered  changed (marked as `M` (meaning "Modified") on the right in the `Changes` list) - double clicking on it will show a preview of the changes made - it is a good practice to look at the locally created changes before commiting them and then pushing them - this is to avoid unwanted code to go to the remote repository:

<img width="1278" alt="image" src="https://user-images.githubusercontent.com/7610713/212551286-b5753d23-f290-48c6-8548-1899459558ac.png">

You can see the newly added line in green.

To commit the changes, first add them by clicking on the `+` button at the right of the `Changes (2)` group - this will add all the changed files to staging and will become ready to commit:

<img width="266" alt="image" src="https://user-images.githubusercontent.com/7610713/212551367-9049f5a3-fce5-4822-9059-a720fb3931a6.png">

Now the `Changes (2)` group shows `Staged Changes (2)` - these changes will be commited. Provide some commit message in the input field above and click `Commit Staged` button:

This is how it looks like just before commiting:

<img width="257" alt="image" src="https://user-images.githubusercontent.com/7610713/212551403-bbe2cc6e-4286-433f-aacc-392dbacb4095.png">

And this is how it looks like after commiting:

<img width="266" alt="image" src="https://user-images.githubusercontent.com/7610713/212551446-129c36de-9219-43ad-adb5-5eb6cd92e5ce.png">

You just commited your changes locally. Now you can push your changes to the remote repository by clicking on the "Arrow Up" which is one of the buttons at the right side of the "Current branch" drop-down. The screen will change to:

<img width="265" alt="image" src="https://user-images.githubusercontent.com/7610713/212551573-d4a982c0-3c9f-4a8f-92c1-1f9662a7178e.png">

Now go and create pull request for this branch to `main`, inspect it and merge it. After the pull request is merged, use the "Current branch" drop-down to select the `main` branch:

<img width="314" alt="image" src="https://user-images.githubusercontent.com/7610713/212551676-2a613383-e0b0-4c78-89b6-4190fc79bfa8.png">

After switching to `main` branch, you will see the `.vs` folder that Visual Studio 2022 has created. This is normal since after you switched to the `main` branch, it does not have `.gitignore` file, git removed the file from your directory (to reflect what the current branch has) and the files of this directory are again shown as newly added files. But because the branch that introduced `.gitignore` file was just merged to `main`, we can pull and get it so git will ignore the `.vs` folder and it will disappear from the changes list. Pull the remote `main` content with the second "Arrow down" button:

<img width="269" alt="image" src="https://user-images.githubusercontent.com/7610713/212552002-05d21318-1df0-433f-88b6-ff28436033a7.png">

You see the informational message above that the local `main` branch was updated with the content of the remote `main` branch and the `Changes` list is now empty - this is beause now the local `main` branch has the `.gitignore` file after we pulled it from GitHub (assuming the pull request that added the `.gitignore` file was merged to `main`) and the `.vs` folder is now ignored.

