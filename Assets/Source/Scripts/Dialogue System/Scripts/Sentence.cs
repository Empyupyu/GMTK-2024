using System;
using UnityEngine;

namespace EDialogue
{
    [Serializable]
    public class Sentence
    {
        [field: SerializeField, TextArea(1, 6)] public string Text { get; private set; }
        [field: SerializeField] public bool Completed { get; private set; }

        public void CompleteSpeach()
        {
            Completed = true;
        }

        public void ResetProgress()
        {
            Completed = false;
        }
    }
}

