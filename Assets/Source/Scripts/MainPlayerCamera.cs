using Cinemachine;
using UnityEngine;

namespace GarbageScaler
{
    public class MainPlayerCamera : MonoBehaviour
    {
        public CinemachineVirtualCamera VirtualCamera { get; private set; }
        
        private void Awake()
        {
            VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
    }
}