using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace EQuest
{
    [Serializable]
    public class TaskMoveToTarget : Task
    {
        [field: SerializeField] public string TargetName { get; protected set; }
        public Transform Target { get; private set; }

        public override void OnBeign()
        {
            var target = GameObject.Find(TargetName);
            Target = target.transform;

            if (Target)
            {
                Debug.Log("Find Target " + Target.name);
            }
            else
            {
                Debug.Log("Target is null");
            }
         
        }

        public override void OnComplete()
        {
            throw new System.NotImplementedException();
        }
    }
}

