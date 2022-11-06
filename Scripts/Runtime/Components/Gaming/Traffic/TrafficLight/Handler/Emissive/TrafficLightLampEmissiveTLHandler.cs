using UnityEngine;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic.TrafficLight.Handler.Emissive
{
    [AddComponentMenu(UnityGameToolingConstants.Menu.Component.Gaming.Traffic.TrafficLightMenu + "/Traffic Light Handler (Lamp Emissive Traffic Light Shader)")]
    [DisallowMultipleComponent]
    public sealed class TrafficLightLampEmissiveTLHandler : TrafficLightLampEmissiveBaseHandler
    {
        #region Inspector Data

        [Header("Shader Keys")]
        [SerializeField]
        private string redShaderKey;
        
        [SerializeField]
        private string yellowShaderKey;
        
        [SerializeField]
        private string greenShaderKey;

        #endregion

        private int _redShaderHash;
        private int _yellowShaderHash;
        private int _greenShaderHash;

        protected override void Awake()
        {
            base.Awake();

            _redShaderHash = Shader.PropertyToID(redShaderKey);
            _yellowShaderHash = Shader.PropertyToID(yellowShaderKey);
            _greenShaderHash = Shader.PropertyToID(greenShaderKey);
        }

        protected override void SwitchRedState(float v)
        {
            _renderer.material.SetColor(_redShaderHash, Color.Lerp(Color.black, emissiveColor, v));
        }

        protected override void SwitchYellowState(float v)
        {
            _renderer.material.SetColor(_yellowShaderHash, Color.Lerp(Color.black, emissiveColor, v));
        }

        protected override void SwitchGreenState(float v)
        {
            _renderer.material.SetColor(_greenShaderHash, Color.Lerp(Color.black, emissiveColor, v));
        }

        protected override void SwitchRedStateEditor(float v)
        {
            GetComponent<MeshRenderer>().sharedMaterial.SetColor(redShaderKey, Color.Lerp(Color.black, emissiveColor, v));
        }

        protected override void SwitchYellowStateEditor(float v)
        {
            GetComponent<MeshRenderer>().sharedMaterial.SetColor(yellowShaderKey, Color.Lerp(Color.black, emissiveColor, v));
        }

        protected override void SwitchGreenStateEditor(float v)
        {
            GetComponent<MeshRenderer>().sharedMaterial.SetColor(greenShaderKey, Color.Lerp(Color.black, emissiveColor, v));
        }
    }
}