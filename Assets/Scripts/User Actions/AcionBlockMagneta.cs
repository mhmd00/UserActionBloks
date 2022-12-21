using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionBlockMagneta : MonoBehaviour
{
    ActionBlockDragging actionBlockDragging;
    GameObject leftBarBack;
    float outMagnetaAreaXValue;

    private void Awake()
    {
        actionBlockDragging = GetComponent<ActionBlockDragging>();
        leftBarBack = GameObject.Find("leftBarBack");
        outMagnetaAreaXValue = (leftBarBack.GetComponent<RectTransform>().position.x +
            (leftBarBack.GetComponent<RectTransform>().rect.width/2)+20);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.transform.position.x> outMagnetaAreaXValue)
        {
            Debug.Log("<color=Yellow> Action Block is in magneta area. </color>");
            StickWithAnotherActionBlock(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        actionBlockDragging.AllowDragging();
    }

    void StickWithAnotherActionBlock(Collider2D collision)
    {
        if (collision.gameObject.tag == "Action Block")
        {
            if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
            {
                actionBlockDragging.PreventDragging();
                gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x,
                    gameObject.transform.position.y - 15);
            }
            //else
            //{
            //    actionBlockDragging.crsrCanDrag = false;
            //    collision.transform.position = new Vector2(gameObject.transform.position.x,
            //       collision.transform.position.y - 15);
            //}
        }
    }
}
