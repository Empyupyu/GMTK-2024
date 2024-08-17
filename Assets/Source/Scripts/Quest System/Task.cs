using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace EQuest
{
    [Serializable]
    public abstract class Task
    {
        public bool IsCompleted;
        public event Action OnCompleted;

        public abstract void OnBeign();
        public abstract void OnComplete();
        
        protected void Complete()
        {
            IsCompleted = true;
            OnCompleted?.Invoke();
        }
    }
}

