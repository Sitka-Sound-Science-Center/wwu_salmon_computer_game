using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class BootDropper : MonoBehaviour
{
    [SerializeField]
    GameObject boot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boot.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
