using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor.Utils;

namespace UnityGameTooling.Editor.game_tooling.Scripts.Editor.Provider
{
    public sealed class GamingProvider : SettingsProvider
    {
        private const string TrafficLightLogging = "PCSOFT_TRAFFIC_LIGHT_LOGGING";
        private const string HoverLogging = "PCSOFT_HOVER_LOGGING";

        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new GamingProvider();
        }

        #endregion

        private bool _trafficLightGroup = true;
        private bool _hoverGroup = true;

        public GamingProvider() : base("Project/Gaming", SettingsScope.Project, new[] { "gaming", "tooling" })
        {
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.HelpBox("Project based gaming settings for diverse useful tooling. See areas below.", MessageType.None);

            _trafficLightGroup = EditorGUILayout.BeginFoldoutHeaderGroup(_trafficLightGroup, "Traffic Light System");
            if (_trafficLightGroup)
            {
                EditorGUI.indentLevel = 1;
                {
                    ExtendedEditorGUILayout.SymbolFieldLeft("Verbose Logging", TrafficLightLogging);
                }
                EditorGUI.indentLevel = 0;
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            _hoverGroup = EditorGUILayout.BeginFoldoutHeaderGroup(_hoverGroup, "Hover System");
            {
                EditorGUI.indentLevel = 1;
                {
                    ExtendedEditorGUILayout.SymbolFieldLeft("Activate System", "PCSOFT_HOVER");
                    EditorGUI.BeginDisabledGroup(
#if PCSOFT_HOVER
                        false
#else
                        true
#endif
                    );
                    {
                        ExtendedEditorGUILayout.SymbolFieldLeft("Verbose Logging", HoverLogging);
                    }
                    EditorGUI.EndDisabledGroup();
                }
                EditorGUI.indentLevel = 0;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}