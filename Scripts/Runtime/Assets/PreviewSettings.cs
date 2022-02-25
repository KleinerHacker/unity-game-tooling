#if !UNITY_EDITOR
using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
#endif
using System;
using UnityEditor;
using UnityEngine;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets
{
    public sealed class PreviewSettings : ScriptableObject
    {
        #region Static Area

#if UNITY_EDITOR
        private const string Path = "Assets/Resources/gaming-preview.asset";
#endif

        public static PreviewSettings Singleton
        {
            get
            {
#if UNITY_EDITOR
                var settings = AssetDatabase.LoadAssetAtPath<PreviewSettings>(Path);
                if (settings == null)
                {
                    Debug.Log("Unable to find preview settings, create new");

                    settings = new PreviewSettings();
                    if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }

                    AssetDatabase.CreateAsset(settings, Path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                return settings;
#else
                return AssetResourcesLoader.Instance.GetAsset<PreviewSettings>();
#endif
            }
        }

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => new SerializedObject(Singleton);
#endif

        #endregion

        #region Inspector Data

        [SerializeField]
        private bool useTooling;

        [SerializeField]
        private string raycaster;

        [SerializeField]
        private PreviewItem[] items;

        #endregion

        #region Properties

        public bool UseTooling => useTooling;

        public string Raycaster => raycaster;

        public PreviewItem[] Items => items;

        #endregion
    }

    [Serializable]
    public sealed class PreviewItem
    {
        #region Inspector Data

        [SerializeField]
        private string key;

        [SerializeField]
        private bool autoRotate;

        [SerializeField]
        private float maxRotation;

        [SerializeField]
        private GameObject previewPrefab;

        [SerializeField]
        private Vector3 previewPosition;

        [SerializeField]
        private Vector3 previewRotation;

        #endregion

        #region Properties

        public string Key => key;

        public bool AutoRotate => autoRotate;

        public float MaxRotation => maxRotation;

        public GameObject PreviewPrefab => previewPrefab;

        public Vector3 PreviewPosition => previewPosition;

        public Vector3 PreviewRotation => previewRotation;

        #endregion
    } 
}