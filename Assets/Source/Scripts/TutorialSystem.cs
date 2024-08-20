using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    public class TutorialSystem : GameSystem
    {
        private CarControl _carControl;
        private CraneController _craneController;

        public CinemachineDollyCart CinemachineDollyCart;
        
        public override void OnInit()
        {
            _carControl = FindObjectOfType<CarControl>();
            _craneController = FindObjectOfType<CraneController>();
        }

        private bool _playerCompletedFirstStep;
        private bool _playerCompletedSecondStep;

        private IEnumerator TutorialLoop()
        {
            //Включаю камеру летящую на игрока
            //отключаем у игрока все кнопки
            
            yield return new WaitForSeconds(1);
            //Камера игрока
            //включаем у игрока все кнопки
            //Включаю стрелку и камеру на стрелку
            //текст описывающий задачу
            yield return new WaitForSeconds(4);
            
            //ждем пока плеер доедет до любого из предметов и подберет мусор
            yield return new WaitUntil(() => _playerCompletedFirstStep);
            
            // отправляем игрока к переработчику стрелкой
            
            yield return new WaitUntil(() => _playerCompletedSecondStep);
            
            // отправляем игрока к магазину стрелкой
            // включаем камеру на магаз к магазину стрелкой
        }
    }
}
