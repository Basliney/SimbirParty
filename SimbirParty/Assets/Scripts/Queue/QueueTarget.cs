using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTarget : MonoBehaviour
{
    [SerializeField] private QueueHandler _queueHandler;
    [SerializeField] private float _releaseTime;
    [SerializeField] public TypeTarget typeTarget;

    void Start()
    {
        _queueHandler = GetComponent<QueueHandler>();
        StartCoroutine(ReleaseCoroutine());
    }

    IEnumerator ReleaseCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);

            _queueHandler.SelfRelease();
        }
    }
}

public enum TypeTarget
{
    Food,
    Alko,
    Quest
}