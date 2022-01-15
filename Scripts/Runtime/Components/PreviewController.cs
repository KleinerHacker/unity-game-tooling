using System;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEngine;
using UnityExtension.Runtime.extension.Scripts.Runtime;
using UnityExtension.Runtime.extension.Scripts.Runtime.Components;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components
{
    [DefaultExecutionOrder(UnityGameToolingConstants.Script.ExecutionOrder.PreviewController)]
    public sealed class PreviewController : SearchingSingletonBehavior<PreviewController>
    {
        #region Static Area

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initialize()
        {
            if (!PreviewSettings.Singleton.UseTooling)
                return;
            
            var go = new GameObject("Preview System");
            go.AddComponent<PreviewController>();
            DontDestroyOnLoad(go);
        }

        #endregion
        
        #region Properties

        public bool IsShown => !string.IsNullOrEmpty(ShownPreview);
        public string ShownPreview => _item?.Key;

        #endregion

        private GameObject _preview;
        private PreviewItem _item;

        #region Builtin Methods

        private void OnEnable()
        {
            Raycaster.AddRaycast(PreviewSettings.Singleton.Raycaster, OnRaycaster);
        }

        private void OnDisable()
        {
            Raycaster.RemoveRaycast(PreviewSettings.Singleton.Raycaster, OnRaycaster);
        }

        #endregion

        public void Show(string key)
        {
            if (IsShown)
            {
                Hide();
            }

            _item = PreviewSettings.Singleton.Items.FirstOrThrow(x => x.Key == key,
                () => new InvalidOperationException("Key '" + key + "' is unknown in previews"));

            _preview = Instantiate(_item.PreviewPrefab);
            _preview.name = "Preview";
        }

        public void Hide()
        {
            if (!IsShown)
                return;

            Destroy(_preview);

            _preview = null;
            _item = null;
        }

        private void OnRaycaster(object sender, RaycasterEventArgs e)
        {
            if (!IsShown || e.Hit == null)
                return;

            _preview.transform.position = _item.PreviewPosition + e.Hit.Value.point;
            if (_item.AutoRotate)
            {
                var euler = Quaternion.FromToRotation(Vector3.up, e.Hit.Value.normal).eulerAngles;
                _preview.transform.rotation = Quaternion.Euler(_item.PreviewRotation) * Quaternion.Euler(
                    Mathf.Clamp(euler.x, -_item.MaxRotation, _item.MaxRotation),
                    euler.y,
                    Mathf.Clamp(euler.y, -_item.MaxRotation, _item.MaxRotation)
                );
            }
        }
    }
}