using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraXTrack : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float fryHeight;

    public bool trackY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = this.transform.position.y;
        if (trackY)
        {
            yPos = Mathf.Lerp(transform.position.y, Player.transform.position.y, 0.75f);
        }
        this.transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.75f), yPos, this.transform.position.z);   
    }

    public void ChangeToFryPosition()
    {
        this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + fryHeight, 0.75f), this.transform.position.z);
    }
}
