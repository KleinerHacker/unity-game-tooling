using UnityEditor;

namespace UnityGameTooling.Editor.game_tooling.Scripts.Editor.Provider
{
    public sealed class GamingProvider : SettingsProvider
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new GamingProvider();
        }

        #endregion
        
        public GamingProvider() : base("Project/Gaming", SettingsScope.Project, new []{"gaming", "tooling"})
        {
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.HelpBox("Project based gaming settings for diverse useful tooling. See areas below.", MessageType.None);
        }
    }
}