using UnityEngine;

public class GeneralUI : MonoBehaviour
{
    public void ToggleScreen(GameObject screen)
    {
        screen.SetActive(!screen.activeSelf);
    }
}
