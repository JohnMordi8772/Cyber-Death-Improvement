/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    public class GibManager : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(Random.Range(6, 10));
            HideUtility.HideGameObject(gameObject);
        }
    }
}
