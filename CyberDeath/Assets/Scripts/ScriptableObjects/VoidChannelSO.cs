/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Represents a channel that objects can subscribe to to handle events
    /// with a no parameters.
    /// </summary>
    [CreateAssetMenu(menuName = "Channels/Void Channel", fileName = "New Void Channel")]
    public class VoidChannelSO : ScriptableObject
    {
        /// <summary>
        /// The event to subscribe to.
        /// </summary>
        public UnityAction OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}