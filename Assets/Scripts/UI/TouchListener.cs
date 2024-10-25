using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchListener : MonoBehaviour, IPointerDownHandler
{
    private FishButton[] StateList;
    private float timer=0F;
    private float phaseTimer=0F;
    private int HighlightState=0;
    [SerializeField]
    private float IdleThreshold=10F;
    [SerializeField]
    private float HighlightDuration=1F;

    /*
    Listen for a global PointerDownEvent and fire this callback
    to stop the idle cycling highlight animation. This callback is fired 
    when ever the PointerDown event occurs. 
    */
    public void OnPointerDown(PointerEventData data) { 
        timer=0F;
    }

    void GetNextAnimationState() {
        StateList[HighlightState].SetSelect(false);
        StateList[(HighlightState+1)%5].SetSelect(true);
        HighlightState++;
    }

    void Awake() {
        StateList=gameObject.GetComponent<LevelSelect>().fishButtons;
    }

    void Update() {
        if (timer<IdleThreshold) timer+=Time.deltaTime;
        if (phaseTimer<HighlightDuration) phaseTimer+=Time.deltaTime;
        if (timer>=IdleThreshold && phaseTimer>=HighlightDuration) {
            GetNextAnimationState();
            phaseTimer=0F;
        }
    }
}
