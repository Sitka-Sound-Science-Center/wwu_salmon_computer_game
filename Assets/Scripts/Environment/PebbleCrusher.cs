using System.Collections;
using UnityEngine;

public class PebbleCrusher : MonoBehaviour
{
    bool crushing;
    [SerializeField]
    private int crushTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pebble"))
        {
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
            StartCoroutine(CrushTimer(reason, collision.gameObject.GetComponent<PlayerController>()));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crushing = false;
        }
    }

    private IEnumerator CrushTimer(string reason, PlayerController player)
    {
        yield return new WaitForSeconds(crushTime);
        if (crushing)
        {
            player.killPlayer(reason);
        }
    }

}
