using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaticDpad : MonoBehaviour
{
    [SerializeField]
    Button UpButton;
    [SerializeField]
    Button DownButton;
    [SerializeField]
    Button LeftButton;
    [SerializeField]
    Button RightButton;
    [SerializeField]
    Transform Player;
    Vector2 Move = new (0,0);

    // Start is called before the first frame update
    void Start()
    {
        UpButton.onClick.AddListener(() => SetMovePlayer(0, 1));
        DownButton.onClick.AddListener(() => SetMovePlayer(0, -1));
        LeftButton.onClick.AddListener(() => SetMovePlayer(-1, 0));
        RightButton.onClick.AddListener(() => SetMovePlayer(1, 0));

        
     
    }

    // Update is called once per frame
    void Update()
    {
        Player.Translate(Move);
    }

    void SetMovePlayer(int x, int y)
    {
        Move = new (x, y);
    }
}
