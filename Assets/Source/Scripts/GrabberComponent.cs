using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    public class GrabberComponent : MonoBehaviour
    {
        [SerializeField] private Transform _grabberPoint;
        [SerializeField] private Transform _grabberBone;
        [SerializeField] private CraneController _craneController;
        [SerializeField] private Collider _collider;
        [SerializeField] private CarControl _carControl;
        [SerializeField] private float _grabDistance;
        [SerializeField] private float _grabPower;
        [SerializeField] private float _grasSphereCastRadius = .2f;
        [SerializeField] private int _garbageLayerMask;

        private bool _isGrab;
        private Rigidbody _target; 
        private float _startTargerMass;
        
        void Start()
        {
            _garbageLayerMask = 1 << 6;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isGrab)
                {
                    _isGrab = false;
                    Destroy(_grabberBone.GetComponent<FixedJoint>());
                    _target.mass = _startTargerMass;
                    _target = null;
                    return;
                }
                
                Ray ray = new Ray(_grabberPoint.position, _grabberPoint.forward);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 5);

                var colliders = Physics.OverlapSphere(_grabberPoint.position, _grasSphereCastRadius, _garbageLayerMask);
                
                if (colliders.Length > 0)
                {
                    _target = colliders[0].GetComponent<Rigidbody>();
                    _startTargerMass = _target.mass;
                    _target.mass = _startTargerMass * (1 - Bootstrap.Instance.GameData.Carry);
                    _craneController.GetCrane().DOLocalMoveY(0.7f, .1f).OnComplete(() =>
                    {
                        _grabberBone.gameObject.AddComponent<FixedJoint>().connectedBody = _target;
                    });

                    _isGrab = true;
                }
            }
        }
    }
}
