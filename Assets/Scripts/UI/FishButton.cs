using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishButton : MonoBehaviour
{
    public ManagePhase.Phase phase;
    public SpeciesManager.Species species;
    public GameObject infoScreen;
    public GameObject highlight;

    public void SetSelect(bool select) {
        if (infoScreen != null && highlight != null)
        {
            infoScreen.SetActive(select);
            highlight.SetActive(infoScreen != null && select);
        }
    }

    public void RefreshImage()
    {
        SpeciesController controller = gameObject.GetComponentInChildren<SpeciesController>();
        controller.RefreshImage();

        highlight.GetComponent<GetSpriteFromParent>().RefreshSprite();
    }
}
