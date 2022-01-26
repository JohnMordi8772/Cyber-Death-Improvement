/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class HideUtility : MonoBehaviour
    {
        public static void HideGameObject(GameObject obj)
        {
            var cols = obj.GetComponents<Collider>();
            foreach (Collider col in cols)
            {
                if (!col.isTrigger)
                    col.enabled = false;
            }

            Destroy(obj, 1f);
        }
    }
}
