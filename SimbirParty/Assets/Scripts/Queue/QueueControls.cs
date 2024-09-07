using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QueueControls : MonoBehaviour
{
    [SerializeField] private List<Transform> queuePositions;

    public Transform GetFreeQueuePlace(Transform transform)
    {
        return queuePositions.Where(x => x != transform).ElementAt(Random.Range(0, queuePositions.Count - 1));
    }

    public void Remove(Transform transform)
    {
        queuePositions.Remove(transform);
    }

    public void Add(Transform transform)
    {
        if (queuePositions.Contains(transform))
            return;

        queuePositions.Add(transform);
    }

    public void GetFreeQueues()
    {
        queuePositions = GameObject.FindGameObjectsWithTag("queuePos")
            .Where(x => x.GetComponent<QueueHandler>().GetState()).Select(x => x.transform).ToList();
    }
}
