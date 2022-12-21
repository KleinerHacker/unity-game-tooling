using System;
using System.Collections.Generic;
using UnityCommonEx.Runtime.common_ex.Scripts.Runtime.Utils.Extensions;
using UnityEngine;
using UnityExtension.Runtime.extension.Scripts.Runtime.Components.Singleton;
using UnityExtension.Runtime.extension.Scripts.Runtime.Components.Singleton.Attributes;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Assets;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Misc;
using UnityPrefsEx.Runtime.prefs_ex.Scripts.Runtime.Utils;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components
{
    [Singleton(Instance = SingletonInstance.RequiresNewInstance, Scope = SingletonScope.Application, CreationTime = SingletonCreationTime.Loading)]
    public sealed class TutorialManager : SingletonBehavior<TutorialManager>
    {
        private TutorialSettings _settings;
        private readonly IDictionary<string, UITutorialDialog> _tutorialDialogs = new Dictionary<string, UITutorialDialog>();

        #region Builtin Methods

        protected override void DoAwake()
        {
            _settings = TutorialSettings.Singleton;

            _tutorialDialogs.Clear();
            foreach (var step in _settings.Steps)
            {
                var canvas = new Func<Canvas>(() =>
                {
                    var canvasGo = GameObject.FindWithTag(_settings.TargetCanvasTag);
                    return canvasGo == null ? FindObjectOfType<Canvas>() : canvasGo.GetComponent<Canvas>();
                }).Invoke();
                
                if (canvas == null)
                    throw new InvalidOperationException("Cannot find any target canvas, tag was " + _settings.TargetCanvasTag);

                var go = Instantiate(step.Dialog, Vector3.zero, Quaternion.identity, canvas.transform);
                _tutorialDialogs.Add(step.Identifier, go.GetComponent<UITutorialDialog>());
            }
        }

        #endregion

        internal void SkipTutorial()
        {
            foreach (var key in _tutorialDialogs.Keys)
            {
                PlayerPrefsEx.SetBool(BuildKey(key), true, true);
            }
        }

        internal void ResetTutorial()
        {
            foreach (var key in _tutorialDialogs.Keys)
            {
                PlayerPrefsEx.SetBool(BuildKey(key), false, true);
            }
            
            PlayerPrefsEx.SetInt(CounterKey, 0, true);
        }

        internal void HandleEvent(string identifier)
        {
            if (PlayerPrefsEx.GetBool(BuildKey(identifier), false))
                return;

            if (!_settings.TryFindStep(identifier, out var step))
            {
                Debug.LogError("Unable to find tutorial step " + identifier);
                return;
            }
            
            if (_settings.OrderedTutorial && PlayerPrefsEx.GetInt(CounterKey, 0) != _tutorialDialogs.Keys.IndexOf(x => x == identifier))
                return;

            _tutorialDialogs[identifier].Show();
            PlayerPrefsEx.SetBool(BuildKey(identifier), true, true);
            PlayerPrefsEx.SetInt(CounterKey, _tutorialDialogs.Keys.IndexOf(x => x == identifier) + 1);
        }

        private string BuildKey(string identifier) => _settings.PlayerPrefsPrefix + "." + identifier;
        private string CounterKey => BuildKey("counter");
    }
}