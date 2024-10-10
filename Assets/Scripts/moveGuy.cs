using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {
    private float fishSpeed=0.015F;
    // Start is called before the first frame update
    void Start() {
        gameObject.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)){
            gameObject.transform.position+=fishSpeed*Vector3.up;
        }
        if (Input.GetKey(KeyCode.A)){
            gameObject.transform.position+=fishSpeed*Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)){
            gameObject.transform.position+=fishSpeed*Vector3.down;
        }
        if (Input.GetKey(KeyCode.D)){
            gameObject.transform.position+=fishSpeed*Vector3.right;
        }
    }

    void OnCollisionEnter2D(){
        print("Fish collider");
    }
    void OnCollisionStay2D() {
        print("Sir the fish has collided with the rocks");
    }
}
