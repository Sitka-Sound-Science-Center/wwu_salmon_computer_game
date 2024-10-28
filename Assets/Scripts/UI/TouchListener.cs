using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchListener : MonoBehaviour, IPointerDownHandler
{
    private FishButton[] StateList;
    private float timer=0F;
    private float phaseTimer=0F;
    public int HighlightState=0;
    private LevelSelect LevelScript;
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

    public void GetNextAnimationState() {
        LevelScript.SelectStage(StateList[(HighlightState+1)%5]);
        HighlightState=(HighlightState+1)%5;
    }

    void Awake() {
        LevelScript=gameObject.GetComponent<LevelSelect>();
        StateList=LevelScript.fishButtons;
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
