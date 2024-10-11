using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrushedRockPopup : MonoBehaviour
{
    [SerializeField]
    GameObject infoBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        infoBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoBox.SetActive(false);
    }
}
