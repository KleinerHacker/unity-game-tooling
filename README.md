# unity-game-tooling
Game Toolings for Unity

# install
Use this repository directly in Unity.

### Dependencies
* https://github.com/KleinerHacker/unity-common-ex
* https://github.com/KleinerHacker/unity-animation

### Open UPM
URL: https://package.openupm.com

Scope: org.pcsoft

# usage

### Cameras
* `FlyingPanningZoomCameraController` is a camera made for simulation views. 
Use it always with `CameraBorder` to setup scrolling borders.

### Preview / Hover System
* `PreviewSystem` to show a pre defines preview on pointer. See `Raycaster` and `Preview System` in project settings
* Inherite from `HoverSystem` to create a simple pointer based over mechanism. System is created automatically on games startup.
