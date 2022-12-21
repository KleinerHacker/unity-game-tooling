using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityUIEx.Runtime.ui_ex.Scripts.Runtime.Components.UI.Window;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Misc
{
    [AddComponentMenu(UnityGameToolingConstants.Menu.Component.MiscMenu + "/Tutorial Dialog")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(UIDialog))]
    public sealed class UITutorialDialog : UIBehaviour
    {
        #region Inspector Data

        [Header("References")]
        [SerializeField]
        private Toggle skipToggle;

        #endregion
        
        private UIDialog _dialog;

        #region Builtin Methods

        protected override void Awake()
        {
            _dialog = GetComponent<UIDialog>();
        }

        #endregion

        public void Show() => _dialog.Show();

        public void Hide() => _dialog.Hide();

        public void Submit()
        {
            _dialog.Hide();
            if (skipToggle != null && skipToggle.isOn)
            {
                TutorialManager.Singleton.SkipTutorial();
            }
        }

        public void SkipTutorial()
        {
            TutorialManager.Singleton.SkipTutorial();
            _dialog.Hide();
        }
    }
}