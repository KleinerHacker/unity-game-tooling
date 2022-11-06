using System;
using UnityEngine;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler.Light
{
    public abstract class TrafficLightLampLightBaseHandler : TrafficLightLampBaseHandler, ITrafficLightLampLightHandler
    {
        #region Inspector Data

        [Header("Lights")]
        [SerializeField]
        protected UnityEngine.Light[] redLights = Array.Empty<UnityEngine.Light>();
        
        [SerializeField]
        protected UnityEngine.Light[] yellowLights = Array.Empty<UnityEngine.Light>();
        
        [SerializeField]
        protected UnityEngine.Light[] greenLights = Array.Empty<UnityEngine.Light>();

        #endregion
    }
}