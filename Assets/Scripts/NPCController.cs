using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform goal;
    private bool timer = true;
    public float wait = 3f;
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
        if (timer)
        {
            timer = false;
            agent.SetDestination(fuzzGoal(goal));
            WaitForSeconds(wait);
        }
        transform.SetPositionAndRotation(transform.position, Quaternion.identity);
    }

    private Vector3 fuzzGoal(Transform goal)
    {
        float fuzz = Random.Range(-5, 5);
        Vector3 result = new Vector3(goal.position.x +  fuzz, goal.position.y + fuzz, goal.position.z + fuzz);
        return result;
    }
    IEnumerator WaitForSeconds(float wait)
    {
        yield return new WaitForSeconds(wait);
        timer = true;
    }
}
