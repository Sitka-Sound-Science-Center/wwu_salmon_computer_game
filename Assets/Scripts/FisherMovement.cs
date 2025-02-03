using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 LeftPatrol = new Vector3(90, 160, 0);
    [SerializeField]
    Vector3 RightPatrol = new Vector3(370, 150, 0);
    [SerializeField]
    float CastFrequency = 3F; // how long between each cast (spawn a fishing hook)
    [SerializeField]
    float speed = 4F; // how much movement
    Vector3 ScaleFactor;
    float timer; // timer to track casting fishing line
    float cur = 0F; // current proportion of distance traveled between left and right patrol points
    float direction = 1F; // moving in positive x-direction or negative x-direction

    void Start() {
        ScaleFactor = gameObject.transform.localScale;
    }

    // spawn fisher hook that can kill you
    // next move: if hook active -- reel it in, perhaps show NPC fish object trailing it and pop up info box about fishing benefits to economy
    // next move: if no hook, move then cast hook like previously
    void Update() {
        timer += Time.deltaTime;
        if (timer >= CastFrequency) {
            float t = Random.Range(0F,1F);
            Vector3 nxt = Vector3.Lerp(LeftPatrol, RightPatrol, t);
            if (t - cur < 0) direction = -1F;
            else direction = 1F;
            gameObject.transform.localScale = new Vector3(direction * ScaleFactor.x, ScaleFactor.y, ScaleFactor.z); 
            cur = t;
            timer = 0;
        }
        gameObject.transform.position += (Time.deltaTime * speed * direction * Vector3.Normalize(RightPatrol - LeftPatrol));
    }
}
