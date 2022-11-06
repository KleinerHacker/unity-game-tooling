using System;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler
{
    public sealed class TrafficLightCommonHandler : ITrafficLightLampHandler
    {
        private readonly ITrafficLightLampHandler[] _trafficLightHandlers;

        public TrafficLightCommonHandler(params ITrafficLightLampHandler[] trafficLightHandlers)
        {
            _trafficLightHandlers = trafficLightHandlers;
        }


        public void SwitchRed(bool on, bool editor = false, Action onFinished = null)
        {
            foreach (var trafficLightHandler in _trafficLightHandlers)
            {
                trafficLightHandler.SwitchRed(on, editor, onFinished);
            }
        }

        public void SwitchYellow(bool on, bool editor = false, Action onFinished = null)
        {
            foreach (var trafficLightHandler in _trafficLightHandlers)
            {
                trafficLightHandler.SwitchYellow(on, editor, onFinished);
            }
        }

        public void SwitchGreen(bool on, bool editor = false, Action onFinished = null)
        {
            foreach (var trafficLightHandler in _trafficLightHandlers)
            {
                trafficLightHandler.SwitchGreen(on, editor, onFinished);
            }
        }
    }
}