using System.Collections.Generic;
using UnityEngine;

namespace EQuest
{
    [CreateAssetMenu(fileName = "Quest (1)", menuName = "Quest/New Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeReference, SubclassSelector] List<Task> tasks;

        public List<Task> Tasks => tasks;
    }
}

