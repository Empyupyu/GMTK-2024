using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GarbageScaler
{
    public class DialogueWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueText;
        
        public bool IsOpened { get; private set; }
        
        public void Show()
        {
            transform.DOScale(Vector3.one, 0.5f).OnComplete(() => IsOpened = true);
        }
        
        public void Hide()
        {
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                IsOpened = false;
                gameObject.SetActive(false);
            });
        }
        
        public void SetText(string text)
        {
            dialogueText.text = text;
        }
    }
}