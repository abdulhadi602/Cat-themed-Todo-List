using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragEventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private static GameObject itemBeingDragged;
    Vector3 startPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
      
        transform.position = Input.mousePosition;
        Debug.Log(startPosition.x-transform.position.x);
        if (startPosition.x - transform.position.x > 150)
        {
            
            Destroy(gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPosition;
    }

  
}
