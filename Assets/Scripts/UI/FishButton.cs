using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishButton : MonoBehaviour
{
    public ManagePhase.Phase phase;
    public GameObject icon;
    public GameObject infoScreen;
    public GameObject highlight;

    public void SetSelect(bool select) {
        if (infoScreen != null && highlight != null)
        {
            infoScreen.SetActive(select);
            highlight.SetActive(infoScreen != null && select);
        }
    }
}
