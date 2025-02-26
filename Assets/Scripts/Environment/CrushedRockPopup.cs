using UnityEngine;

public class CrushedRockPopup : MonoBehaviour
{
    [SerializeField]
    GameObject infoBox;

    void Start()
    {
        infoBox.SetActive(false);
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
