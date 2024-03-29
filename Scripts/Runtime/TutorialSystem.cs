﻿using System;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
#if PCSOFT_TUTORIAL
    using Components;

    public static class TutorialSystem
    {
        public static void FireEvent(string identifier, Action onFinished = null) => TutorialManager.Singleton.HandleEvent(identifier, onFinished);

        public static void Deactivate() => TutorialManager.Singleton.SkipTutorial();

        public static void Reset() => TutorialManager.Singleton.ResetTutorial();

        public static void HideCurrent() => TutorialManager.Singleton.HideCurrent();
    }
#endif
}