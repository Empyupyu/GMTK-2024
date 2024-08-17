using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EDialogue
{
    [Serializable]
    public class Answer
    {
        [field: SerializeField] public Sentence AnswerText { get; private set; }
        [field: SerializeField] public List<Speech> Speachs { get; private set; }
        [field: SerializeField] public List<UnityEvent> OnChoice { get; private set; }
        [field: SerializeField] public List<OnChoiceEvent> OnChoiceEvents { get; private set; }
    }
}