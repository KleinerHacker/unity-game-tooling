using UnityEngine;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler.Emissive
{
    public abstract class TrafficLightLampEmissiveSingleRendererBaseHandler : TrafficLightLampEmissiveBaseHandler
    {
        protected Renderer _renderer;

        protected virtual void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }
    }
}