using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
#if PCSOFT_PREVIEW && PCSOFT_RAYCASTER
    public static class PreviewSystem
    {
        public static bool IsShown => PreviewController.Singleton.IsShown;
        public static string ShownPreview => PreviewController.Singleton.ShownPreview;
        
        public static void Show(string key) => PreviewController.Singleton.Show(key);
        public static void Hide() => PreviewController.Singleton.Hide();
    }
#endif
}