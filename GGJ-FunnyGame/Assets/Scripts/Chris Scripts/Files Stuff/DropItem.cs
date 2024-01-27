using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public GameObject Image;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
}
