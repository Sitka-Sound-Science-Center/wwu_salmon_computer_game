using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetEaten : MonoBehaviour
{
    [SerializeField]
    GameObject mouthPosition;
    private DeathReason reason;
    public bool busyEating = false;
    // Start is called before the first frame update
    void Start()
    {
        reason = this.GetComponent<DeathReason>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.busyEating)
        {
            StartCoroutine(WaitForSeconds(3f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!busyEating && other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerS>().disablePlayer(reason.reason);
            //other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.isKinematic = true;
            other.transform.SetPositionAndRotation(mouthPosition.transform.position, Quaternion.identity);
            
        }
        if (other.gameObject.CompareTag("NPC"))
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            busyEating = true;
            other.attachedRigidbody.isKinematic = true;
            other.transform.SetPositionAndRotation(mouthPosition.transform.position, Quaternion.identity);
        }
    }

    IEnumerator WaitForSeconds(float wait)
    {
        yield return new WaitForSeconds(wait);
        busyEating = false;
    }
}
