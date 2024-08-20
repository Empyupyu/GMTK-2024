using System;
using DG.Tweening;
using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GarbageScaler.UIScreens
{
    public class DialogueUIScreen : UIScreen
    {
        [SerializeField] private DialogueWindow dialogueWindow;

        public override void Subscribe()
        {
            Signals.Get<ShowDialogueWindowSignal>().AddListener(ShowDialogueWindow);
            Signals.Get<HideDialogueWindowSignal>().AddListener(HideDialogueWindow);
            
            dialogueWindow.transform.localScale = Vector3.zero;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                ShowDialogueWindow("hello" + Random.Range(0, 100));
            
            if (Input.GetMouseButtonDown(1))
                HideDialogueWindow();
        }

        private void ShowDialogueWindow(string text)
        {
            if (dialogueWindow.IsOpened)
            {
                dialogueWindow.transform.DOScale(Vector3.zero, 0.5f)
                    .OnComplete(() =>
                    {
                        dialogueWindow.SetText(text);
                        dialogueWindow.Show();
                    });
                return;
            }

            dialogueWindow.SetText(text);
            dialogueWindow.gameObject.SetActive(true);
            dialogueWindow.Show();
        }
        
        private void HideDialogueWindow()
        {
            dialogueWindow.Hide();
        }
    }
}