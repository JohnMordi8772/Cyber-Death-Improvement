/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Bool Channel")]
    public class BoolChannelSO : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
