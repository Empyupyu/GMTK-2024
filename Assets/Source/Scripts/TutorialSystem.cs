using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;

namespace GarbageScaler
{
    public class TutorialSystem : GameSystem
    {
        private CarControl _carControl;
        private CraneController _craneController;

        public GameObject Arrow1, Arrow2, Arrow3, Arrow4;

        public CinemachineVirtualCamera C1;
        public CinemachineVirtualCamera C2;
        public CinemachineVirtualCamera C3;
        public CinemachineVirtualCamera C4;
        
        public override void OnInit()
        {
            _carControl = FindObjectOfType<CarControl>();
            _craneController = FindObjectOfType<CraneController>();

            C2?.gameObject.SetActive(false);
            C3?.gameObject.SetActive(false);
            C4?.gameObject.SetActive(false);
            Arrow1?.SetActive(false);
            // Arrow2?.SetActive(false);
            // Arrow3?.SetActive(false);
            // Arrow4?.SetActive(false);

            StartCoroutine(TutorialLoop());
        }

        private bool _playerCompletedFirstStep;
        private bool _playerCompletedSecondStep;

        private IEnumerator TutorialLoop()
        {
            //Включаю камеру летящую на игрока
            //отключаем у игрока все кнопки
            _carControl.enabled = false;
            _craneController.enabled = false;
            
            C1.gameObject.SetActive(false);
            C2.gameObject.SetActive(true);
          
            
            yield return new WaitForSeconds(2.9f);

            C2.gameObject.SetActive(false);
            C3.gameObject.SetActive(true);
            
            yield return new WaitForSeconds(2);
            
            _carControl.enabled = true;
            _craneController.enabled = true;
            
            yield return new WaitForSeconds(.5f);
            
            // Arrow1.SetActive(true);
            
            // Signals.Get<ShowDialogueWindowSignal>().Dispatch("какой-то текст");
            //Камера игрока
            //включаем у игрока все кнопки
            //Включаю стрелку и камеру на стрелку
            //текст описывающий задачу
            yield return new WaitForSeconds(4);
            
            // Signals.Get<ShowDialogueWindowSignal>().Dispatch("какой-то текст");
            
            //ждем пока плеер доедет до любого из предметов и подберет мусор
            yield return new WaitUntil(() => _playerCompletedFirstStep);
            
            // отправляем игрока к переработчику стрелкой
            
            yield return new WaitUntil(() => _playerCompletedSecondStep);
            
            // отправляем игрока к магазину стрелкой
            // включаем камеру на магаз к магазину стрелкой
        }
    }
}
