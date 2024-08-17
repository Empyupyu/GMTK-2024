using System;
using System.Collections.Generic;
using UnityEngine;

namespace EDialogue
{
    [CreateAssetMenu(fileName = "Dialogue (1)", menuName = "Dialogue/New Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [field: SerializeField] public List<Speech> Speeches { get; private set; }

        public event Action OnDialogueCompleted;

        private Speech LastSpeaker;
        private Sentence LastSpeach;

        [ContextMenu("Reset Progress")]
        private void ResetProgress()
        {
            for (int i = 0; i < Speeches.Count; i++)
            {
                for (int s = 0; s < Speeches[i].Speachs.Count; s++)
                {
                    if (!Speeches[i].Speachs[s].Completed) continue;

                    LastSpeach = Speeches[i].Speachs[s];
                    LastSpeach.ResetProgress();
                }
            }
        }

        public Sentence GetNextSpeach()
        {
            for (int i = 0; i < Speeches.Count; i++)
            {
                for (int s = 0; s < Speeches[i].Speachs.Count; s++)
                {
                    if (Speeches[i].Speachs[s].Completed) continue;

                    LastSpeaker = Speeches[i];
                    LastSpeach = Speeches[i].Speachs[s];

                    return LastSpeach;
                }
            }

            OnDialogueCompleted?.Invoke();
            Debug.Log("OnDialogueCompleted Event");

            return null;
        }

    

        public void CompleteSpeach()
        {
            LastSpeach.CompleteSpeach();
        }

        public Speech GetSpeaker()
        {
            return LastSpeaker;
        }
    }
}

