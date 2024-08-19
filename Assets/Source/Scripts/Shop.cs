using GarbageScaler.GameSignals;
using Supyrb;
using UnityEngine;

namespace GarbageScaler
{
    public class Shop : MonoBehaviour
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<Player>() != null)
                Signals.Get<PlayerEnteredShopSignal>().Dispatch();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInParent<Player>() != null)
                Signals.Get<PlayerExitedShopSignal>().Dispatch();
        }
    }
}