using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GarbageScaler
{
    public class GrabberComponent : MonoBehaviour
    {
        [SerializeField] private Transform _grabberPoint;
        [SerializeField] private CraneController _craneController;
        [SerializeField] private FixedJoint _fixedJoint;
        [SerializeField] private Collider _collider;
        [SerializeField] private CarControl _carControl;
        [SerializeField] private float _grabDistance;
        [SerializeField] private float _grabPower;
        [SerializeField] private int _garbageLayerMask;

        private bool _isGrab;
        private Rigidbody _target;
        void Start()
        {
            _garbageLayerMask = 1 << 6;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                _isGrab = false;
                _fixedJoint.connectedBody = null;
                _target = null;
                _collider.enabled = true;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ray ray = new Ray(_grabberPoint.position, _grabberPoint.forward);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 5);

                if (Physics.Raycast(ray, out var hit, _grabDistance, _garbageLayerMask))
                {
                    if (hit.collider)
                    {
                        _craneController.SetPosition(hit.point);
                        // hit.collider.GetComponent<Rigidbody>().centerOfMass = hit.point;
                        // hit.collider.GetComponent<Rigidbody>().Ce = hit.point;

                        _target = hit.collider.GetComponent<Rigidbody>();
                        // _target.transform.parent = transform;
                        // _target.isKinematic = true;
                        _collider.enabled = false;
                        _fixedJoint.connectedBody = _target;
                        _isGrab = true;
                        // hit.collider.i
                    }
                }
            }

     
            // _target.velocity = new Vector3(_carControl.rigidBody.velocity.x, _target.velocity .y,_carControl.rigidBody.velocity.z);
            // _target.position =
            //     Vector3.MoveTowards(_target.position, _grabberPoint.position, _grabPower * Time.deltaTime);
        }
    }
}
