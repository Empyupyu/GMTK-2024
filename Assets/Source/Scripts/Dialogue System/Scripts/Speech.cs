using System;
using System.Collections.Generic;
using UnityEngine;

namespace EDialogue
{
    [Serializable]
    public class Speech
    {
        [field: SerializeField] public string SpeakerName { get; private set; }
        [field: SerializeField] public List<Sentence> Speachs { get; private set; }
        [field: SerializeField] public List<Answer> Answers { get; private set; }
    }
}

