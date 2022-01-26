/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/16/2021
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// A channel which carries a float value.
    /// </summary>
    [CreateAssetMenu(menuName = "Channels/Float Channel", fileName = "New Float Channel")]
    public class FloatChannelSO : ScriptableObject
    {
        /// <summary>
        /// The UnityAction to subscribe to.
        /// </summary>
        public UnityAction<float> OnEventRaised;

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <param name="value">The float to pass to the event.</param>
        public void RaiseEvent(float value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}