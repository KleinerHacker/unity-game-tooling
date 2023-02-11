using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime;
using UnityEngine;
using UnityExtension.Runtime.extension.Scripts.Runtime.Components;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets;
#if PCSOFT_RAYCASTER && PCSOFT_HOVER
using System;
using System.Linq;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components;
#endif

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
    public static class UnityGameToolingStartupEvents
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeLater()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initialize()
        {


#if PCSOFT_TUTORIAL
            Debug.Log("Initialize tutorial system");
            AssetResourcesLoader.LoadFromResources<TutorialSettings>(""); 
#endif
        }
    }
}