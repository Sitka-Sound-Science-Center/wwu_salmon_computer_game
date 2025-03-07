using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesManager : ScriptableObject
{
    public enum Species
    {
        Coho,
        Sockeye,
        Pink,
        Chum,
        Chinook
    }

    public static Species curSpecies = Species.Chum;

    public static void SetSpecies(Species newSpecies)
    {
        curSpecies = newSpecies;
    }
}
