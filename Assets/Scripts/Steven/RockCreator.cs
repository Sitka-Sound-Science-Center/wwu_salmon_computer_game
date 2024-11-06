using Codice.Client.Common.GameUI;
using Codice.CM.Client.Differences.Merge;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(RectTransform))]
[RequireComponent (typeof(int))]
public class RockCreator : MonoBehaviour
{

    private int counter = 0;
    [SerializeField]
    private RectTransform spawnableArea;
    [SerializeField]
    private int RockFieldHeight;
    [SerializeField]
    private float rocksPerSecond;
    [SerializeField]
    private int maxRockCount;
    [SerializeField]
    private string size;


    private Vector3 position;
    private Quaternion rotation;
    private float randomOffset;
    private float spawnPointOriginY;
    private int rockCount;
    private Vector2 area;

    //range values derived
    private float x_lower;
    private float y_lower;
    private float x_upper;
    private float y_upper;
    
    private GameObject pebble;
    private GameObject pebbleB;
    private List<GameObject> pebbles = new List<GameObject>();

    // Start is called before the first frame update
    
    void Start()
    {
        switch (size) {
            case "small":
            //spawnPointOriginY = spawnPoint.position.y;
            pebble = Resources.Load<GameObject>("PhysicsPebble");
            pebbleB = Resources.Load<GameObject>("PhysicsPebbleB");
            pebbles.Add(pebble);
            pebbles.Add(pebbleB);
            break;

            case "medium":
                pebbles.Add(Resources.Load<GameObject>("PhysicsPebbleM1"));
                pebbles.Add(Resources.Load<GameObject>("PhysicsPebbleM2"));
                break;
            default:
                break;
        }
        //derive spawn range
        float rectX = this.GetComponent<RectTransform>().rect.x + this.GetComponent<RectTransform>().position.x; //left edge of transform
        float rectY = this.GetComponent<RectTransform>().rect.y + this.GetComponent<RectTransform>().position.y; //bottom edge of transform
        Vector2 area = this.GetComponent<RectTransform>().sizeDelta;
        x_lower = rectX;
        x_upper = rectX + area.x;
        y_lower = rectY;
        y_upper = rectY + area.y;

        print("start has run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        counter += 1;
        if (rockCount < maxRockCount && counter == 50/(rocksPerSecond)) //once per second
        {
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            SpawnARock();
            rockCount += 10;
            counter = 0;
        }
    }
    
    private Vector3 newPosition()
    {
        position = new Vector3(Random.Range(x_lower, x_upper), Random.Range(y_lower, y_upper), 0f);
        return position;
    }

    private void SpawnARock() {

        Vector3 spawnPosition = newPosition();
        Quaternion spawnRotation = Quaternion.Euler(getRandomAngle()); 
        
        GameObject pebblen = Instantiate(getRandPebble(), spawnPosition, spawnRotation, this.transform);
        

    }

    private GameObject getRandPebble()
    {
        int rnd = Random.Range(0, pebbles.Count);
        
        return pebbles[rnd];    
    }

    private Vector3 getRandomAngle()
    {
        
        Vector3 v = new Vector3(0f, 0f, Random.Range(0,360));
        return v;
    }

}
