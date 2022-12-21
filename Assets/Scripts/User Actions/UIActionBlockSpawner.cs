using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserActions
{
    public class UIActionBlockSpawner : MonoBehaviour
    {
        [HideInInspector]public BarActionsScriptable barActionsScriptable;
        GameObject actionBlockPrefab;
        [HideInInspector]public GameObject actionsParentObject;
        [SerializeField] Transform actionsStartTransform;
        [SerializeField] float yAxisActionSeparteSpace;
        List<GameObject> actionBlocksSortedByYAxisValue = new List<GameObject>();
        List<GameObject> actionBlocksList = new List<GameObject>();
        private void Awake()
        {
            SetupActionBar();
        }
        private void Start()
        {
            SpawnBarActions();
        }

        void SpawnBarActions()
        {
            int numOfInstatiatedActionBlocks=0;
            foreach (ActionBlock actionBlock in barActionsScriptable.ActionBlocks)
            {
                actionsStartTransform.position -= new Vector3(0, yAxisActionSeparteSpace, 0);
                GameObject actionBlockInstance = Instantiate(actionBlockPrefab,
                    (actionsStartTransform.position), Quaternion.identity) as GameObject;
                numOfInstatiatedActionBlocks++;
                actionBlockInstance.name = "Action Block " + numOfInstatiatedActionBlocks;
                if (actionBlockInstance.gameObject.GetComponent<Image>())
                    actionBlockInstance.gameObject.GetComponent<Image>().color = actionBlock.actionColor;
                if (actionBlockInstance.gameObject.GetComponentInChildren<Text>())
                    actionBlockInstance.gameObject.GetComponentInChildren<Text>().text = actionBlock.actionName;
                actionBlockInstance.transform.SetParent(actionsParentObject.transform,true);
            }
        }

        public List<GameObject> OrderInstantiatedActionBlocks()
        {
            actionBlocksList.Clear();
            for (int i = 0; i <actionsParentObject.transform.childCount; i++)
            {
                actionBlocksList.Add(actionsParentObject.transform.GetChild(i).gameObject);
            }
            actionBlocksSortedByYAxisValue =
                Utils.GameObjectUtils.SortByDistance(actionBlocksList);
            return actionBlocksSortedByYAxisValue;
        }
        void SetupActionBar()
        {
            if (Resources.Load<BarActionsScriptable>("Scriptable/Bars/Bar Actions 1"))
                barActionsScriptable = Resources.Load<BarActionsScriptable>("Scriptable/Bars/Bar Actions 1");
            if (Resources.Load<GameObject>("Prefabs/Action Block"))
                actionBlockPrefab = Resources.Load<GameObject>("Prefabs/Action Block") as GameObject;
            actionsParentObject = new GameObject("Actions Parent");
            actionsParentObject.transform.parent = GameObject.Find("Canvas").transform;
        }
    }
}