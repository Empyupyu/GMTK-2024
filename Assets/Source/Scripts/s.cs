using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GarbageScaler
{
    public class s : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

public class CraneController : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        
        _targetPoint.localPosition += new Vector3()
    }
}