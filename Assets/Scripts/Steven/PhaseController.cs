using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

[RequireComponent(typeof(string))]
public class PhaseController : MonoBehaviour
{
    [SerializeField]
    private string phaseCurrent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhase(string nextPhase)
    {
        print("change phase reached");
        switch (nextPhase)
        {
            case "Alevin":
                print("why are you changing to alevin...?");
                break;
            case "Fry":
                print("Changing to Fry");
                setPhase("Fry");
                break;
            case "Smolt":

            default:
                print("something went wrong in phase changer");
                break;
        }

    }

    private void setPhase(string phase)
    {
        //disable current phase
        GameObject p = GetComponentInChildren<GameObject>(GameObject.Find(phaseCurrent));
        p.SetActive(false);

        //enable next phsae
        GetComponentInChildren<GameObject>(GameObject.Find(phase)).SetActive(true);
        
        
    }
}
