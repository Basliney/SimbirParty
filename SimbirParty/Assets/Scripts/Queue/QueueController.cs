using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    void Awake()
    {
        GetComponent<QueueControls>().GetFreeQueues();
        
    }
}
