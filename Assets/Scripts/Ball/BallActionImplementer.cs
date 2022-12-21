using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BallActionImplementer : MonoBehaviour
{
    [SerializeField] UserActions.UIActionBlockSpawner actionBlockSpawner;
    [SerializeField] BallActions ballActions;
    List<GameObject> orderedActionBlocks;
    int numOfActionBlocks;
    public void ImplementActions()
    {
        ballActions.CreateDictionaryOfBallActions();
        numOfActionBlocks = actionBlockSpawner.OrderInstantiatedActionBlocks().Count;
        orderedActionBlocks = actionBlockSpawner.OrderInstantiatedActionBlocks();
        StartCoroutine(DoActions());
    }

    IEnumerator DoActions()
    {
        for (int i = 0; i < numOfActionBlocks; i++)
        {
            string actionName = orderedActionBlocks[i].
                  GetComponentInChildren<BlockAction>().currentBlockAction.ToString();
            foreach (var ballAction in ballActions.BallActionsMethods)
            {
                if (ballAction.Key == actionName)
                {
                    ballActions.BallActionsMethods[actionName]();
                    yield return new WaitForSeconds(1);
                    break;
                }
            }
        }
        yield return new WaitForSeconds(1);
    }
}
