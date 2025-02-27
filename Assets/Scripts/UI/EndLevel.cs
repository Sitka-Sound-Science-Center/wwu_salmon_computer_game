using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeLevel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        Debug.Log("changing level");
        Time.timeScale = 0;
        GameObject.Find("UICanvas/DeathScreens/EndLevel").SetActive(true);
    }
}
