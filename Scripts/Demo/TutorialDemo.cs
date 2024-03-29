﻿#if DEMO
using UnityEngine;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime;

namespace UnityGameTooling.Demo.game_tooling.Scripts.Demo
{
    public sealed class TutorialDemo : MonoBehaviour
    {
        public void ResetTutorial()
        {
            TutorialSystem.Reset();
        }

        public void HideCurrent()
        {
            TutorialSystem.HideCurrent();
        }

        public void ShowPage1()
        {
            TutorialSystem.FireEvent("p1");
        }

        public void ShowPage2()
        {
            TutorialSystem.FireEvent("p2");
        }

        public void ShowPage3()
        {
            TutorialSystem.FireEvent("p3");
        }
    }
}
#endif