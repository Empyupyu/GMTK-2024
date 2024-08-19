using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GarbageScaler
{
    public class PhysicsBone : MonoBehaviour
    {
        [SerializeField] private Transform _animationBone;
        [SerializeField] private ConfigurableJoint _physicsBone;

        private Quaternion _startRotation;

        private void Start()
        {
            _startRotation = transform.localRotation;
        }

        void FixedUpdate()
        {
            _physicsBone.targetRotation = Quaternion.Inverse(_animationBone.localRotation) * _startRotation;
        }
    }
}
