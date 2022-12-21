using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserActions
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Bar Actions ", menuName = "Bars/Actions Bar", order = 1)]
    public class BarActionsScriptable : ScriptableObject
    {
        [Header(" Set Action Blocks' values ")]
        public ActionBlock[] ActionBlocks;
    }
}