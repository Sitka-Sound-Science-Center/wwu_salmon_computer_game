using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSpriteFromParent : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void OnEnable()
    {
        bool isUI = gameObject.GetComponent<Image>();
        Sprite useSprite;
        if (isUI)
        {
            useSprite = parent.GetComponent<Image>().sprite;
            gameObject.GetComponent<Image>().sprite = useSprite;

        } else
        {
            useSprite = parent.GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = useSprite;
        }
    }

    public void RefreshSprite()
    {
        OnEnable();
    }
}
