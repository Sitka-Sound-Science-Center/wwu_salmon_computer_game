using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JSTouch : MonoBehaviour
{

    public GameObject player;
    private Vector3 move;
    private Vector3 initialpos;
    private Vector3 distance;
    void Start()
    {
        move = Vector3.zero;
    }
    void Update()
    {
        player.transform.position += move * Time.deltaTime;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialpos = transform.position;
        move = Vector3.zero;

    }
    //#endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        distance = Input.mousePosition - initialpos;
        distance = Vector3.ClampMagnitude(distance, 45 * Screen.width / 708);
        transform.position = initialpos + distance;
        move = distance.normalized;


    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        move = Vector3.zero;
        transform.position = initialpos;
    }


    #endregion

}