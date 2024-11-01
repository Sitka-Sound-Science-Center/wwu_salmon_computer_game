using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(RectTransform))]
[RequireComponent (typeof(int))]
public class RockCreator : MonoBehaviour
{

    private int counter=1;
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

    void LoadSmallPebbles() {
        pebbles.Add(Resources.Load<GameObject>("PhysicsPebble"));
        pebbles.Add(Resources.Load<GameObject>("PhysicsPebbleB"));
    }

    void LoadMediumPebbles () {
        pebbles.Add(Resources.Load<GameObject>("PhysicsPebbleM1"));
        pebbles.Add(Resources.Load<GameObject>("PhysicsPebbleM2"));
    }

    void Awake() {
        if (size=="small") LoadSmallPebbles();
        else LoadMediumPebbles();
    }

    // Start is called before the first frame update
    void Start() {
        //left edge of transform
        float rectX = this.GetComponent<RectTransform>().rect.x;
        float posX = this.GetComponent<RectTransform>().position.x; 
        //bottom edge of transform
        float rectY = this.GetComponent<RectTransform>().rect.y;
        float posY = this.GetComponent<RectTransform>().position.y; 
        Vector2 area = this.GetComponent<RectTransform>().sizeDelta;
        x_lower = rectX + posX;
        x_upper = rectX + posX + area.x;
        y_lower = rectY + posY;
        y_upper = rectY + posY + area.y;
    }

    // Called 50 times per second since FixedTimestep is 0.02 seconds
    private void FixedUpdate() {
        counter++;
        // Spawn 10 rocks every other update
        if (rockCount < maxRockCount && counter%3==0) {
            SpawnKRocks(10);
            rockCount += 10;
        }
    }
    
    private Vector3 newPosition() {
        position = new Vector3(Random.Range(x_lower, x_upper), Random.Range(y_lower, y_upper), 0f);
        return position;
    }

    private void SpawnARock() {
        Vector3 spawnPosition = newPosition();
        Quaternion spawnRotation = Quaternion.Euler(getRandomAngle()); 
        GameObject pebblen = Instantiate(getRandPebble(), spawnPosition, spawnRotation);
    }

    private void SpawnKRocks(int k) {
        for (int i=0;i<k;i++) {
            SpawnARock();
        }
    }

    private GameObject getRandPebble() {
        int rnd = Random.Range(0, pebbles.Count);
        return pebbles[rnd];    
    }

    private Vector3 getRandomAngle() {
        Vector3 v = new Vector3(0f, 0f, Random.Range(0,360));
        return v;
    }
}
