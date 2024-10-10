using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject currentInfo;

    private string curSpecies;
    private string curStage;
    // the key is the name of the lifecycle stage
    // the value is an array of its GameObjects: [info screen, highlight]
    public Dictionary<string, GameObject[]> stages = new Dictionary<string, GameObject[]>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage(string stage)
    {
        foreach (KeyValuePair<string, GameObject[]> entry in stages)
        {
            entry.Value[0].SetActive(entry.Key == stage);
            entry.Value[1].SetActive(entry.Key == stage);
        }
    }

    private void SetHighlight(string stage)
    {
        
    }

    public void SelectSpecies(string species)
    {
        this.curSpecies = species;
    }
}
