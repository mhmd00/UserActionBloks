using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockAction : MonoBehaviour
{
    [HideInInspector] public ActionType currentBlockAction;

    private void Start()
    {
        string[] ActionTypeNames = System.Enum.GetNames(typeof(ActionType));
        foreach (var actionTypeName in ActionTypeNames)
        {
            if(actionTypeName== gameObject.GetComponentInChildren<Text>().text.Replace(" ",""))
            {
                currentBlockAction = (ActionType)System.Enum.Parse(typeof(ActionType), actionTypeName);
            }
        }
    }
}
