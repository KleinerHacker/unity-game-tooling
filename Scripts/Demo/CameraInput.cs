#if DEMO
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Cameras;

namespace UnityGameTooling.Demo.game_tooling.Scripts.Demo
{
    [RequireComponent(typeof(FlyingPanningZoomCameraController))]
    public sealed class CameraInput : MonoBehaviour
    {
        private FlyingPanningZoomCameraController _cameraController;

        private void Awake()
        {
            _cameraController = GetComponent<FlyingPanningZoomCameraController>();
        }

        private void Update()
        {
            var f = Mouse.current.scroll.ReadValue().y;
            if (f != 0f)
            {
                _cameraController.Zoom(-f);
            }
        }
    }
}
#endif