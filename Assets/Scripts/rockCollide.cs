using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Started rock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter (Collision other) {
        print("A collider has made contact with the Rock Collider");
    }
}
