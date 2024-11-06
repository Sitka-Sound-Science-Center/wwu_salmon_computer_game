using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//perhaps change this to a despawn trigger instead of a static timer?
public class onscreenTimer : MonoBehaviour
{
    [SerializeField]
    float TimeOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        StartCoroutine(textboxDespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator textboxDespawnDelay()
    {
        yield return new WaitForSecondsRealtime(TimeOnScreen);
        this.gameObject.SetActive(false);
    }
}
