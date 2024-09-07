using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class HumanControls : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private Transform destination;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        destination = targets[0];
        _agent.SetDestination(destination.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target" && other.name == destination.name)
        {
            destination = targets.Where(x=>x != destination).ElementAt(UnityEngine.Random.Range(0, targets.Length -1));
            _agent.SetDestination(destination.position);
        }
    }
}
