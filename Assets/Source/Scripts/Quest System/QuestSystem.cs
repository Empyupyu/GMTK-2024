using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EQuest
{
    public class QuestSystem : MonoBehaviour
    {
        [field: SerializeField] public List<Quest> Quests { get; private set; }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                Quests[0].Tasks[0].OnBeign();
            }
        }
    }
}

