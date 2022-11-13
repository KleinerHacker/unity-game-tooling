using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor.Utils;

namespace UnityGameTooling.Editor.game_tooling.Scripts.Editor.Provider
{
    public sealed class GamingProvider : SettingsProvider
    {
        private const string TrafficLightLogging = "TRAFFIC_LIGHT_DEBUG";
        
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new GamingProvider();
        }

        #endregion

        private bool _verboseLogging = true;
        
        public GamingProvider() : base("Project/Gaming", SettingsScope.Project, new []{"gaming", "tooling"})
        {
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.HelpBox("Project based gaming settings for diverse useful tooling. See areas below.", MessageType.None);

            _verboseLogging = EditorGUILayout.BeginFoldoutHeaderGroup(_verboseLogging, "Verbose Logging");
            if (_verboseLogging)
            {
                EditorGUI.indentLevel = 1;
                {
                    ExtendedEditorGUILayout.SymbolFieldLeft("Traffic Light Logging", TrafficLightLogging);
                }
                EditorGUI.indentLevel = 0;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}