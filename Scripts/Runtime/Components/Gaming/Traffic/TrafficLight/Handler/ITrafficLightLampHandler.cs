using System;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler
{
    public interface ITrafficLightLampHandler
    {
        void SwitchRed(bool on, bool editor = false, Action onFinished = null);
        
        void SwitchYellow(bool on, bool editor = false, Action onFinished = null);
        
        void SwitchGreen(bool on, bool editor = false, Action onFinished = null);
    }
}