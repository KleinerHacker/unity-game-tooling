using System;
using System.Collections.Generic;
using System.Linq;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityExtension.Runtime.extension.Scripts.Runtime.Assets;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets;

namespace UnityGameTooling.Editor.game_tooling.Scripts.Editor.Provider
{
    public sealed class PreviewProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new PreviewProvider();
        }

        #endregion

        private SerializedObject _serializedObject;
        private SerializedProperty _useToolingProperty;
        private SerializedProperty _raycasterProperty;
        private SerializedProperty _itemsProperty;

        private string[] _raycastItems;

        private PreviewList _previewList;
        
        public PreviewProvider() : base("Project/Gaming/Preview System", SettingsScope.Project, new []{"gaming", "tooling", "preview"})
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _serializedObject = PreviewSettings.SerializedSingleton;
            if (_serializedObject == null)
                return;

            _useToolingProperty = _serializedObject.FindProperty("useTooling");
            _raycasterProperty = _serializedObject.FindProperty("raycaster");
            _itemsProperty = _serializedObject.FindProperty("items");
            
            _raycastItems = RaycastSettings.Singleton.Items.Select(x => x.Key).ToArray();

            _previewList = new PreviewList(_serializedObject, _itemsProperty);
        }

        public override void OnGUI(string searchContext)
        {
            _serializedObject.Update();
            
            EditorGUILayout.HelpBox("Setup existing preview objects to show or hide this with or setup defined states.", MessageType.None);
            EditorGUILayout.PropertyField(_useToolingProperty, new GUIContent("Activate Preview System"));

            EditorGUI.BeginDisabledGroup(!_useToolingProperty.boolValue);
            if (string.IsNullOrEmpty(PreviewSettings.Singleton.Raycaster))
            {
                EditorGUILayout.HelpBox("Please choose a raycaster. A raycaster is required for this tooling!", MessageType.Error);
            }

            var index = _raycastItems.IndexOf(x => string.Equals(x, _raycasterProperty.stringValue, StringComparison.Ordinal));
            var newIndex = EditorGUILayout.Popup("Raycaster for preview:", index, _raycastItems);
            if (index != newIndex)
            {
                _raycasterProperty.stringValue = newIndex < 0 ? null : _raycastItems[newIndex];
            }
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Previews", EditorStyles.boldLabel);
            if (PreviewSettings.Singleton.Items.Any(x => string.IsNullOrEmpty(x.Key)))
            {
                EditorGUILayout.HelpBox("Some keys are empty!", MessageType.Warning);
            }
            if (PreviewSettings.Singleton.Items.HasDoublets(x => x.Key))
            {
                EditorGUILayout.HelpBox("Some keys are defined multiple times", MessageType.Warning);
            }
            _previewList.DoLayoutList();
            EditorGUI.EndDisabledGroup();

            _serializedObject.ApplyModifiedProperties();
        }
    }
}