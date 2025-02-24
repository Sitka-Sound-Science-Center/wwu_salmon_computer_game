using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform goal;
    public int timer = 0;
    public int frequency_s = 3;
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

    private void FixedUpdate()
    {
        if (timer > frequency_s * 20)
        {
            timer = 0;
            agent.SetDestination(fuzzGoal(goal));
        }
        timer++;

    }

    private Vector3 fuzzGoal(Transform goal)
    {
        float fuzz = Random.Range(-15, 15);
        Vector3 result = new Vector3(goal.position.x, goal.position.y, goal.position.z + fuzz);
        return result;
    }
    
}
