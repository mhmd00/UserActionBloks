using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ActionBlockDragging : MonoBehaviour
{
    Canvas canvas;
    bool crsrCanDrag=true;

    private void Awake()
    {
        crsrCanDrag = true;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void AllowDragging()
    {
        crsrCanDrag = true;
    }
    public void PreventDragging()
    {
        crsrCanDrag = false;
    }
    public void Drag(BaseEventData data)
    {
        if(crsrCanDrag)
        {
            PointerEventData pointerEventData = (PointerEventData)data;
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerEventData.position,
                canvas.worldCamera,
                out pos);
            transform.position = canvas.transform.TransformPoint(pos);
        }
      
    }
}
