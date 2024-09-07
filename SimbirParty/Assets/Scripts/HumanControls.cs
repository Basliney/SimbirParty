using System;
using UnityEngine;
using UnityEngine.AI;

public class HumanControls : MonoBehaviour
{
    [SerializeField] private QueueHandler _queueHandler;
    [SerializeField] private QueueControls _queueControls;
    [SerializeField] private Transform _destination;
    private NavMeshAgent _agent;
    [SerializeField] public Transform reservedPlace;

    void Start()
    {
        GetComponentInChildren<QueueHandler>().name = Guid.NewGuid().ToString();
        _agent = this.GetComponent<NavMeshAgent>();
        SetNewTarget();
        _agent.SetDestination(_destination.position);
    }

    private void Update()
    {
        _agent.SetDestination(_destination.position);
    }

    public void SetNewTarget()
    {
        _destination = _queueControls.GetFreeQueuePlace(_queueHandler.transform);
    }

    public void SetNewTarget(Transform transform)
    {
        _destination = _queueControls.GetFreeQueuePlace(_queueHandler.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "queuePos" && _destination.name == other.name && reservedPlace == null)
        {
            var queueHandler = other.GetComponent<QueueHandler>();
            if (queueHandler.TakePlace())
            {
                ReservePlace(other);
                _queueHandler.ReleasePlace();
            }
            else
            {
                SetNewTarget(queueHandler.transform);
                _agent.SetDestination(_destination.position);
            }
        }
        if (other.tag == "target" && other.name == _destination.name)
        {
            SetNewTarget();
            _agent.SetDestination(_destination.position);
        }
    }

    public void ReleaseCurrentTarget()
    {
        _queueHandler.TakePlace();
        _queueHandler.humanControls?.SwapDestination(_destination);
        SetNewTarget();
        _agent.SetDestination(_destination.position);
        reservedPlace = null;
    }

    public void SwapDestination(Transform destination)
    {
        reservedPlace = null;
        _destination = destination;
        _agent.SetDestination(_destination.position);
    }

    private void ReservePlace(Collider other)
    {
        other.GetComponent<QueueHandler>().humanControls = this;
        reservedPlace = other.transform;
    }
}
