#if DEMO
using UnityEngine;
using UnityGameTooling.Runtime.game_tooling.Scripts.Runtime;

namespace UnityGameTooling.Demo.game_tooling.Scripts.Demo
{
    public sealed class PreviewActivator : MonoBehaviour
    {
        private void Start()
        {
            PreviewSystem.Show("cube");
        }
    }
}
#endif