using UnityEngine;

[RequireComponent(typeof(string))]
[RequireComponent(typeof(GameObject))]

public class PhaseChanger : MonoBehaviour
{
    public ManagePhase.Phase phase;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision:" + collision.GetComponent<Collider2D>().name);
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player collision");
            player.GetComponent<PhaseController>().ChangePhase(phase);
            ManagePhase.SetPhase(phase);
            // update phase and disable trigger so you cant go back in time?
            //enable textbox
            
            textBox.SetActive(true);
            // prevent re triggering
            gameObject.SetActive(false);
        }
    }
}
