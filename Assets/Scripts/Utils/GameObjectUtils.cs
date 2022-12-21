using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public static class GameObjectUtils 
    {
        public static List<GameObject> SortByDistance(this List<GameObject> objects)
        {
            return objects.OrderBy(go => -go.transform.position.y).ToList();
        }
    }
}