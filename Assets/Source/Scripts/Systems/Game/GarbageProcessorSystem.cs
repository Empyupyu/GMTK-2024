using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;

namespace GarbageScaler.Systems.Game
{
    public class GarbageProcessorSystem : GameSystem
    {
        public override void OnInit()
        {
            Signals.Get<GarbageCollectedSignal>().AddListener(ProcessGarbage);
        }

        private void ProcessGarbage(GarbageConsumer garbageConsumer, Garbage garbage, Vector3 contactPoint)
        {
            ConsumeGarbage(garbage, contactPoint);
            CreateProcessedGarbage(garbageConsumer);
        }

        private void ConsumeGarbage(Garbage garbage, Vector3 contactPoint)
        {
            Signals.Get<AddMoneySignal>().Dispatch(garbage.Value);
            var vfx = Instantiate(config.ProcessedGarbageVfxPrefab, contactPoint,
                Quaternion.Euler(-90, 0, 0));

            Destroy(vfx.gameObject, 4);
            Destroy(garbage.gameObject);
        }

        private void CreateProcessedGarbage(GarbageConsumer garbageConsumer)
        {
            var processedGarbage = Instantiate(config.ProcessedGarbagePrefab,
                garbageConsumer.OutputPoint.position, Quaternion.identity);

            var shootVector = new Vector3(Random.Range(-1f, 1), 1, Random.Range(-1f, 1));
            processedGarbage.Rigidbody.velocity = shootVector * 5f;
        }
    }
}