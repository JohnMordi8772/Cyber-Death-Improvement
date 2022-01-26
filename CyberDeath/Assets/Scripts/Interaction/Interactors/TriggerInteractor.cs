/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Assigns interactables via Triggers.
    /// </summary>
    public class TriggerInteractor : IInteractor
    {
        /// <summary>
        /// Assigned the collided interactable.
        /// </summary>
        /// <param name="other">The Collider that we entered the trigger of.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                IInteractable interactable = other.GetComponent<IInteractable>();
                AssignInteractable(interactable);
            }
        }

        /// <summary>
        /// Unassigns the interactable if we left the trigger of
        /// the currently assigned interactable.
        /// </summary>
        /// <param name="other">The Collider that we entered the trigger of.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                IInteractable interactable = other.GetComponent<IInteractable>();

                if (interactable == GetInteractable())
                {
                    UnassignInteractable();
                }
            }
        }
    }
}