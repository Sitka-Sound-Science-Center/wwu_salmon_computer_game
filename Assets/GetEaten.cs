using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    [SerializeField]
    GameObject mouthPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerS>().disablePlayer();
            //other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.isKinematic = true;
            other.transform.SetPositionAndRotation(mouthPosition.transform.position, Quaternion.identity);
        }
    }
}
