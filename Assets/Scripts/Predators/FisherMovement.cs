using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherMovement : MonoBehaviour
{
    // Public: 
    [SerializeField]
    GameObject FishHook;
    [SerializeField]
    Vector3 LeftPatrol = new Vector3(90, 160, 0);
    [SerializeField]
    Vector3 RightPatrol = new Vector3(370, 150, 0);
    [SerializeField]
    int lines = 1; // how many fishing lines out at once (outriggers)
    [SerializeField]
    float CastFrequency = 3F; // how long between each cast (spawn a fishing hook)
    [SerializeField]
    float speed = 4F; // how much movement
    // Private: 
    Vector3 ScaleFactor;
    GameObject castLine;
    float timer; // timer to track casting fishing line
    float cur = 0F; // current proportion of distance traveled between left and right patrol points
    float direction = 1F; // moving in positive x-direction or negative x-direction
    int LineCount = 0; // current count of fishing lines out

    void Start() {
        ScaleFactor = gameObject.transform.localScale;
    }

    // next move: if hook active -- reel it in, perhaps show NPC fish object trailing it and pop up info box about fishing benefits to economy
    void Update() {
        timer += Time.deltaTime;
        if (timer >= CastFrequency && LineCount >= lines) {
            Destroy(castLine);
            LineCount--;
            timer=0;
        }
        else if (timer >= CastFrequency && LineCount < lines) {
            float t = Random.Range(0F,1F);
            Vector3 nxt = Vector3.Lerp(LeftPatrol, RightPatrol, t);
            Vector3 linePos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 20, 0);
            if (t - cur < 0) direction = -1F;
            else direction = 1F;
            gameObject.transform.localScale = new Vector3(direction * ScaleFactor.x, ScaleFactor.y, ScaleFactor.z); 
            castLine = GameObject.Instantiate(FishHook, linePos, gameObject.transform.rotation);
            LineCount++;
            cur = t;
            timer = 0;
        } 
        gameObject.transform.position += (Time.deltaTime * speed * direction * Vector3.Normalize(RightPatrol - LeftPatrol));
    }
}
