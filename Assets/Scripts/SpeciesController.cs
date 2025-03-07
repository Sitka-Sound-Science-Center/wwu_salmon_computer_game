using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesController : MonoBehaviour
{
    public Sprite cohoSprite;
    public Sprite sockeyeSprite;
    public Sprite pinkSprite;
    public Sprite chumSprite;
    public Sprite chinookSprite;

    private bool isUI;

    void Start()
    {
        isUI = gameObject.GetComponent<Image>();
        SpeciesManager.Species species = SpeciesManager.curSpecies;

        switch(species)
        {
            case SpeciesManager.Species.Coho:
                SetImage(cohoSprite);
                break;
            case SpeciesManager.Species.Sockeye:
                SetImage(sockeyeSprite);
                break;
            case SpeciesManager.Species.Pink:
                SetImage(pinkSprite);
                break;
            case SpeciesManager.Species.Chum:
                SetImage(chumSprite);
                break;
            case SpeciesManager.Species.Chinook:
                SetImage(chinookSprite);
                break;

        }
    }

    private void SetImage(Sprite selected)
    {
        if (isUI)
            gameObject.GetComponent<Image>().sprite = selected;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = selected;
    }

    public void RefreshImage()
    {
        Start();
    }
}
