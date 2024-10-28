using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(string))]
[RequireComponent(typeof(GameObject))]
public class PhaseChanger : MonoBehaviour
{
    [SerializeField]
    private string phaseName;
    [SerializeField]
    private GameObject player;
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
        print("Collision:" + collision.GetComponent<Collider2D>().name);
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player collision");
            player.GetComponent<PhaseController>().ChangePhase(phaseName);
        }
    }
}
