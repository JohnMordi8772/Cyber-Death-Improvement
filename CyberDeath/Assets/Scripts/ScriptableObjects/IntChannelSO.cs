/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/13/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.Events;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Channels/Int Channel", fileName = "New Int Channel")]
    public class IntChannelSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}