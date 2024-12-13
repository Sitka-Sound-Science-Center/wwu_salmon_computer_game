using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class BootDropper : MonoBehaviour
{
    [SerializeField]
    GameObject boot;
    [SerializeField]
    GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boot.GetComponent<Rigidbody2D>().isKinematic = false;
            //send message to UI canvas to display habitat distruciton message
            textBox.SetActive(true);
        }
    }
}
