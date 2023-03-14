using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public int errorValue;

    private void Start()
    {
        errorValue = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            errorValue++;   
        }
    }
}
