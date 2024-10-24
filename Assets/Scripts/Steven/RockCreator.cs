using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //spawnPointOriginY = spawnPoint.position.y;
        pebble = Resources.Load<GameObject>("PhysicsPebble");
        pebbleB = Resources.Load<GameObject>("PhysicsPebbleB");
        pebbles.Add(pebble);
        pebbles.Add(pebbleB);

        //derive spawn range
        float rectX = this.GetComponent<RectTransform>().rect.x + this.GetComponent<RectTransform>().position.x; //left edge of transform
        float rectY = this.GetComponent<RectTransform>().rect.y + this.GetComponent<RectTransform>().position.y; //bottom edge of transform
        Vector2 area = this.GetComponent<RectTransform>().sizeDelta;
        x_lower = rectX;
        x_upper = rectX + area.x;
        y_lower = rectY;
        y_upper = rectY + area.y;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        counter += 1;
        if (rockCount < maxRockCount && counter == 50/rocksPerSecond) //once per second
        {
            SpawnARock();
            rockCount += 1;
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
        
        GameObject pebblen = Instantiate(getRandPebble(), spawnPosition, spawnRotation);
        

    }

    private GameObject getRandPebble()
    {
        int rnd = Random.Range(0, pebbles.Count);
        print(rnd);
        return pebbles[rnd];    
    }
    private Vector3 getRandomAngle()
    {
        
        Vector3 v = new Vector3(0f, 0f, Random.Range(0,360));
        return v;
    }
}
