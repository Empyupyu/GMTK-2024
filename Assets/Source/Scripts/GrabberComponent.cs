using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GarbageScaler
{
    public class GrabberComponent : MonoBehaviour
    {
        [SerializeField] private Transform _grabberPoint;
        [SerializeField] private CraneController _craneController;
        [SerializeField] private float _grabDistance;
        [SerializeField] private int _garbageLayerMask;
        
        void Start()
        {
            _garbageLayerMask = 1 << 6;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                
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
                        
                    }
                }
            }
        }
    }
}
