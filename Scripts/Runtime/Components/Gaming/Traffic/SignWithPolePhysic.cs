using System;
using UnityEngine;

namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime.Components.Gaming.Traffic
{
    [AddComponentMenu(UnityGameToolingConstants.Menu.Component.Gaming.TrafficMenu + "/Sign With Pole Physic")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class SignWithPolePhysic : MonoBehaviour
    {
        #region Inspector Data

        [Header("Data")]
        [SerializeField]
        private float signMass = 1f;

        [SerializeField]
        private float poleMass = 10f;

        [SerializeField]
        private float signPoleBreakForce = 100f;

        [SerializeField]
        private float poleEarthBreakForce = 1000f;

        [Header("References")]
        [SerializeField]
        private GameObject pole;

        #endregion

        #region Builtin Methods

        private void Awake()
        {
            if (pole == null)
                throw new InvalidOperationException("No pole defined!");
            if (pole.GetComponent<MeshFilter>() == null)
                throw new InvalidOperationException("Pole requires a mesh filter!");

            var boxColliderSign = gameObject.AddComponent<BoxCollider>();
            boxColliderSign.size = GetComponent<MeshFilter>().mesh.bounds.size;
            var rigidBodySign = gameObject.AddComponent<Rigidbody>();
            rigidBodySign.mass = signMass;

            var boxColliderPole = pole.AddComponent<BoxCollider>();
            boxColliderPole.size = pole.GetComponent<MeshFilter>().mesh.bounds.size - Vector3.up;
            var rigidBodyPole = pole.AddComponent<Rigidbody>();
            rigidBodyPole.mass = poleMass;

            var fixedJointSign = gameObject.AddComponent<FixedJoint>();
            fixedJointSign.breakForce = signPoleBreakForce;
            fixedJointSign.connectedBody = rigidBodyPole;
            fixedJointSign.enablePreprocessing = false;

            var fixedJointPole = pole.AddComponent<FixedJoint>();
            fixedJointPole.breakForce = poleEarthBreakForce;
            fixedJointPole.enablePreprocessing = false;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (pole == null && transform.childCount > 0)
            {
                pole = transform.GetChild(0).gameObject;
            }
        }
#endif

        #endregion
    }
}