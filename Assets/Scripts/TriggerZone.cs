using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [TagSelector]
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
