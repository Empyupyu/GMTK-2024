using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EDialogue 
{
    public class DialogueWindow : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Message { get; private set; }
        [field: SerializeField] public Button AnswerButton1 { get; private set; }
        [field: SerializeField] public Button AnswerButton2 { get; private set; }


    }
}

