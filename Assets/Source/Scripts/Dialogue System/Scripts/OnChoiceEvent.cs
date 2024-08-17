using UnityEngine;

namespace EDialogue
{
    public abstract class OnChoiceEvent : ScriptableObject
    {
        public abstract void OnChoice();
    }
}