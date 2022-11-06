using UnityEngine;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler.Emissive
{
    public abstract class TrafficLightLampEmissiveBaseHandler : TrafficLightLampBaseHandler, ITrafficLightLampEmissiveHandler
    {
        #region Inspector Data

        [Header("Lights")]
        [SerializeField]
        [ColorUsage(false, true)]
        protected Color emissiveColor = Color.white * 10_000f;

        #endregion
    }
}