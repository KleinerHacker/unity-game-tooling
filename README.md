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
* `FlyingPanningZoomCameraController` is a camera made for simulation views. 
Use it always with `CameraBorder` to setup scrolling borders.

* `Traffic Light Controller` and `Traffic Light Cross Controller` is a controller for a simple traffic light. There are two presets:
  * `Traffic Light Preset` is a hookup for the light flow. Builtin is German, International, Only Green, Only Green and Yellow and Pedestrian Light
  * `Traffic Light Cross Preset` is a preset for a cross hookup between multiple traffic lights
  
  On the `Traffic Light Cross Preset` you assign the traffic lights based on the chosen cross preset.
* The `Traffic Light Controller` requires an `ITrafficLightLampLightHandler` and an `ITrafficLightLampEmissiveHandler`:
  * `ITrafficLightLampLightHandler`
    * `TrafficLightLampLightDefaultHandler` - assign existing lights
  * `ITrafficLightLampEmissiveHandler`
    * `TrafficLightLampEmissiveTLHandler` - only for traffic lights with a material of TrafficLight shader
    * `TrafficLightLampEmissiveIndexHandler` - for multiple material traffic lights
    * `TrafficLightLampEmissiveMultipleRendererHandler` - for multiple renderer in a traffic light

  > :warning: The traffic light system is currently developed for HDRP only!

* `TutorialSystem` - enables you to create simple dialog based tutorials. See in project settings "Player/Tutorial System" to setup it and use class `UITutorialDialog` in combination with `UIDialog` to create tutorial dialog pages. Link this pages with tutorial global settings and an ID. If you want to dire a tutorial relevant event use this: `TutorialSystem.FireEvent("MyTriggerIdentifier")`. To reset the tutorial use `TutorialSystem.Reset()`. The tutorial sate will stored automatically in player prefs by Tutorial System.
