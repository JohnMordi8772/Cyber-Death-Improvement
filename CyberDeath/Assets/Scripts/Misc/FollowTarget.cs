/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/08/2021
*******************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    public class FollowTarget : MonoBehaviour
    {
        [Tooltip("The target to follow.")]
        [SerializeField] private Transform target;

        private void Update()
        {
            SetPosition();
        }

        /// <summary>
        /// Sets the local position of the Transform to the target's local position.
        /// </summary>
        [Button("Set Position", ButtonSizes.Medium)]
        private void SetPosition()
        {
            transform.localPosition = target.localPosition;
        }
    }
}
