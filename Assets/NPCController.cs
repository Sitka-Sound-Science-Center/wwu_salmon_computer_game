using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        agent.SetDestination(goal.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(transform.position, Quaternion.identity);
    }
}
