namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Misc
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityUIEx.Runtime.ui_ex.Scripts.Runtime.Components.UI.Window;

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
#if PCSOFT_TUTORIAL
                TutorialManager.Singleton.SkipTutorial();
#endif
            }
        }

        public void SkipTutorial()
        {
#if PCSOFT_TUTORIAL
            TutorialManager.Singleton.SkipTutorial();
#endif
            _dialog.Hide();
        }
    }
}