using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    [SerializeField]
    GameObject mouthPosition;
    private DeathReason reason;
    // Start is called before the first frame update
    void Start()
    {
        reason = this.GetComponent<DeathReason>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerS>().disablePlayer(reason.reason);
            //other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.isKinematic = true;
            other.transform.SetPositionAndRotation(mouthPosition.transform.position, Quaternion.identity);
            
        }
    }
}
