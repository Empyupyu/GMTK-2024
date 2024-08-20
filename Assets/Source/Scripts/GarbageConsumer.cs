using GarbageScaler.GameSignals;
using Supyrb;
using UnityEngine;

namespace GarbageScaler
{
    public class GarbageConsumer : MonoBehaviour
    {
        [field: SerializeField] public Transform OutputPoint { get; private set; }
        
        private void OnCollisionEnter(Collision other)
        {
            var garbage = other.gameObject.GetComponentInParent<Garbage>();
            if (garbage != null)
                Signals.Get<GarbageCollectedSignal>().Dispatch(this, garbage, other.contacts[0].point);
        }
    }
}