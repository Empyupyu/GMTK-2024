using System;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public event Action<Transform> OnTriggerEnterEvent;
    public event Action<Transform> OnTriggerExitEvent;
    public event Action<Transform> OnTriggerStayEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
       OnTriggerExitEvent?.Invoke(other.transform); 
    }   

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayEvent?.Invoke(other.transform); 
    }
}
