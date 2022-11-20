using System;
using System.Linq;
using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime;
using UnityEngine;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
    public static class UnityGameToolingStartupEvents
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initialize()
        {
            Debug.Log("Initialize hover system");
            var hoverTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(HoverController).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToArray();
            foreach (var hoverType in hoverTypes)
            {
                Debug.Log("> Create hover system " + hoverType.Name);
                
                var go = new GameObject("Hover System (" + hoverType.Name + ")");
                go.AddComponent(hoverType);
                GameObject.DontDestroyOnLoad(go);
            }
            
            Debug.Log("Initialize preview system");
            AssetResourcesLoader.LoadFromResources<PreviewSettings>("");
        }
    }
}