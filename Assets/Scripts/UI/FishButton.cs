using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishButton : MonoBehaviour
{
    public GameObject infoScreen;
    public GameObject highlight;

    public void SetSelect(bool select)
    {
        infoScreen.SetActive(select);
        highlight.SetActive(select);
    }
}
