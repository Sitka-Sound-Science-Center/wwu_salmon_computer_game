using System.Collections;
using UnityEngine;

public class PebbleCrusher : MonoBehaviour
{
    bool crushing;
    [SerializeField]
    private int crushTime;
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
        if (collision.gameObject.CompareTag("Pebble"))
        {
            print("pebble detected");
            CircleCollider2D component;
            if (collision.TryGetComponent(out component))
            {
                //if pebble and has collider2D
                //disable just the circle collider, NOT the polygon collider
                component.enabled = false;
            }
            collision.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        else if (collision.gameObject.CompareTag("Player")){
            //begin crush timer
            crushing = true;
            string reason = this.GetComponent<DeathReason>().reason;
            StartCoroutine(crushTimer(reason, collision.gameObject.GetComponent<PlayerController>()));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crushing = false;
        }
    }

    private IEnumerator crushTimer(string reason, PlayerController player)
    {
        yield return new WaitForSeconds(crushTime);
        if (crushing)
        {
            player.killPlayer(reason);
            
        }
    }

}
