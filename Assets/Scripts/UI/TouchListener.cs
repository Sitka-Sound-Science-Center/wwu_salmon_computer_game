using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchListener : MonoBehaviour
{
    public Animator animator;
    private float timer=0F;
    [SerializeField]
    private float IdleThreshold=10F;
    private AnimatorClipInfo[] ClipInfo;
    private AnimatorStateInfo StateInfo;
    private string ClipName;

    public string GetCurrentClipName() {
        int layerIndex = 0;
        ClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex); 
        return ClipInfo[0].clip.name;
    }

    bool IsPlayingIdleHiglight() {
        return (ClipName=="IdleHighlight") && (StateInfo.normalizedTime>=0F);
    }

    /*
    Listen for a global PointerDownEvent and fire this callback
    to stop the idle cycling highlight animation which is fired
    on any touch or mouse event
    */
    public void onPointerDown() { 
        if (IsPlayingIdleHiglight()) {
            animator.SetTrigger("StopIdle"); // Stop the animation
        }

        timer=0F;
    }

    void Start() {
        animator=gameObject.GetComponent<Animator>();
    }

    void Update() {
        if (timer<IdleThreshold) timer+=Time.deltaTime;
        StateInfo = animator.GetCurrentAnimatorStateInfo(0);
        ClipName = GetCurrentClipName();
        if (timer>=IdleThreshold && !IsPlayingIdleHiglight()) {
            animator.SetTrigger("IdleHighlight"); // Start the animation
        }
    }
}
