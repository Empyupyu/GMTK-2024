using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GarbageScaler.UIScreens
{
    public class ShopUpgradeUI : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TextMeshProUGUI LevelText;
        [SerializeField] private TextMeshProUGUI CostText;
        [SerializeField] private GameObject LockPanel;
        
        public event Action OnClick;
        
        private bool _isClickable = true;
        private bool _isLocked = false;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isClickable)
                return;
            
            OnClick?.Invoke();
        }

        public void EnableClicking()
        {
            if (_isLocked)
                return;
            
            _isClickable = true;
        }
        
        public void DisableClicking()
        {
            _isClickable = false;
        }

        public void UpdateData(int level, int cost)
        {
            LevelText.text = $"Level {level}";
            CostText.text = $"{cost}";
        }

        public void Lock()
        {
            _isLocked = true;
            DisableClicking();
            LockPanel.SetActive(true);
        }
        
        public void Unlock()
        {
            _isLocked = false;
            EnableClicking();
            LockPanel.SetActive(false);
        }
    }
}