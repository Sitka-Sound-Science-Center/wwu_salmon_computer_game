using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesController : MonoBehaviour
{
    public Sprite cohoSprite;
    public Sprite sockeyeSprite;
    public Sprite pinkSprite;
    public Sprite chumSprite;
    public Sprite chinookSprite;

    void Start()
    {
        SpeciesManager.Species species = SpeciesManager.curSpecies;

        switch(species)
        {
            case SpeciesManager.Species.Coho:
                gameObject.GetComponent<SpriteRenderer>().sprite = cohoSprite;
                break;
            case SpeciesManager.Species.Sockeye:
                gameObject.GetComponent<SpriteRenderer>().sprite = sockeyeSprite;
                break;
            case SpeciesManager.Species.Pink:
                gameObject.GetComponent<SpriteRenderer>().sprite = pinkSprite;
                break;
            case SpeciesManager.Species.Chum:
                gameObject.GetComponent<SpriteRenderer>().sprite = chumSprite;
                break;
            case SpeciesManager.Species.Chinook:
                gameObject.GetComponent<SpriteRenderer>().sprite = chinookSprite;
                break;

        }
    }
}
