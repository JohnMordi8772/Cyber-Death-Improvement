/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/16/2021
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Channels/HealthData Channel", fileName = "New HealthData Channel")]
    public class HealthDataChannelSO : ScriptableObject
    {
        public UnityAction<HealthData> OnEventRaised;

        public void RaiseEvent(HealthData data)
        {
            OnEventRaised?.Invoke(data);
        }
    }
}
