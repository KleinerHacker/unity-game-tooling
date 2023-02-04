namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components
{
#if PCSOFT_RAYCASTER && PCSOFT_HOVER
    using UnityEngine;
    using UnityExtension.Runtime.extension.Scripts.Runtime;

    /// <summary>
    /// Base class to handle hover controller. Is created automatically.
    /// </summary>
    public abstract class HoverController : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// Return name for raycaster ro use. See <see cref="Raycaster"/>
        /// </summary>
        protected abstract string RaycasterName { get; }

        #endregion

        private RaycastHit? _currentHit;

        #region Builtin Methods

        protected virtual void OnEnable()
        {
            Raycaster.AddRaycastChanged(RaycasterName, OnRaycast);
        }

        protected virtual void OnDisable()
        {
            Raycaster.RemoveRaycastChanged(RaycasterName, OnRaycast);
        }

        #endregion

        private void OnRaycast(object sender, RaycasterEventArgs e)
        {
            if (e.Hit == null && _currentHit != null)
            {
#if PCSOFT_HOVER_LOGGING
                Debug.Log("Last game object exit: " + _currentHit.Value.collider.gameObject.name, _currentHit.Value.collider);
#endif
                OnExit(_currentHit.Value.collider.gameObject);
                _currentHit = null;
            }
            else if (e.Hit != null)
            {
                if (_currentHit != null)
                {
#if PCSOFT_HOVER_LOGGING
                    Debug.Log("Last game object exit: " + _currentHit.Value.collider.gameObject.name, _currentHit.Value.collider);
#endif
                    OnExit(_currentHit.Value.collider.gameObject);
                    _currentHit = null;
                }

                if (OnFilter(e.Hit.Value))
                {
#if PCSOFT_HOVER_LOGGING
                    Debug.Log("New game object entered: " + e.Hit.Value.collider.gameObject.name, e.Hit.Value.collider);
#endif
                    OnEnter(e.Hit.Value.collider.gameObject);
                    _currentHit = e.Hit;
                }
            }
        }

        /// <summary>
        /// Is called if hit is not <c>null</c> and <see cref="OnFilter"/> returns true.
        /// </summary>
        /// <param name="gameObject">Game object of collision</param>
        protected abstract void OnEnter(GameObject gameObject);

        /// <summary>
        /// Is called if hit is <c>null</c> or changed to another game object.
        /// </summary>
        /// <param name="gameObject">Game object that is leaved now</param>
        protected abstract void OnExit(GameObject gameObject);

        /// <summary>
        /// Override this method to filter raycast hits before <see cref="OnEnter"/> is called.
        /// </summary>
        /// <param name="hit">Hit object of raycast (only if raycast hits an object)</param>
        /// <returns><c>true</c> to call <see cref="OnEnter"/>, <c>false</c> to ignore hit</returns>
        protected virtual bool OnFilter(RaycastHit hit) => true;
    }
#endif
}