﻿using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
    public static class TutorialSystem
    {
        public static void FireEvent(string identifier) => TutorialManager.Singleton.HandleEvent(identifier);

        public static void Deactivate() => TutorialManager.Singleton.SkipTutorial();

        public static void Reset() => TutorialManager.Singleton.ResetTutorial();
    }
}