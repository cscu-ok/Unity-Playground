# CSCU Game Development - Unity Introduction and Playground
Welcome! This is the repository for the CSCU's game development sandbox. Here, new Unity developers can experiment with the game engine, version control practices, and get a feel for the pull request review cycle on GitHub.

**Project Lead**: Carson Bennett

## Project Requirements
|Application|Version|Purpose|Install Location|
|-----------|-------|-------|----------------|
|Unity|Unity 6000.6.4f1 - MUST be exact version|Game engine that runs the game and allows for modelling, animation, and scripting integrations.|For those who don't have Unity: https://unity.com/products/unity-personal (requires account creation) For those who need the specific version: https://unity.com/releases/editor/archive|
|Visual Studio Code|Any recent version|Scripting|https://code.visualstudio.com/download|

## Repository Cloning Instructions

#### 1. Cloning
1. Create a local folder where you'd like to hold the project on your laptop (Ideally outside the reach of a cloud service).
2. In VS Code, open the newly created folder, then the terminal (`Ctrl+Shift+U`/`Cmd+Shift+U`).
4. In the terminal, type `git clone https://github.com/cscu-ok/Unity-Playground.git` and hit enter.
5. Navigate to project folder `cd unity-playground.`

#### 2. Unity Integration 
**Ensure you're using the correct Unity version of 6000.6.4f1**
1. Open Unity Hub > Add > Add project from disk.
2. Navigate to cloned project folder and select it (make sure to select the cloned github folder, NOT the folder for holding the project).

#### 3. Visual Studio Code Integration
1. In Unity, go to Edit > Preferences > External Tools.
2. Set "External Script Editor" to "Visual Studio Code."
3. Click "Regenerate project files."

## Version Control Basics
Below are some steps of basic version control:
1. Before starting work, always pull from main (`git pull origin main`).
2. Make sure to branch out from main before working in Unity of VS Code (New branch: `git checkout -b <<your-branch-name>>` Existing branch: `git checkout <<your-branch-name>>`).
3. Save changes frequently, and when ready to commit, you can use VS Code's built in panel, or through the terminal by following the steps below:

If first time pushing the branch to GitHub, set the upstream tracking link:
```bash
git add .                                    # stage all changes
git commit -m "your commit message here"     # commit with message
git push -u origin feature/your-feature-name    # push to GitHub
```

On subsequent commits to the same branch, simply do:
```bash
git add .
git commit -m "your commit message here"
git push
```

4. When ready for code to be merged with main, open a pull request through the GitHub online repository.

## Unity Version Control Standards
Unity version control practice isn't too much different from traditional software engineering. However, it is more complicated in that changing non-code items (i.e. modeling, animation, etc.) affects the game engine's metadata. This means that two people
working in the same scene will have merge conflicts on Unity metadata making resolution a huge headache. 

To avoid this headache, we will be following the outline below when starting off on a new development task:
1. Create branch and navigate to it.
2. Duplicate the scene you intend on changing.
3. Rename the duplicated scene something memorable and start making your changes there.
4. Once done, open a PR.
5. Merged PR will bring over your scene to main branch conflict free.
6. At the end of the sprint period, we will combine the duplicated scenes into one.
7. Upon the next sprint, our main scene will be fully updated and ready for further development.
