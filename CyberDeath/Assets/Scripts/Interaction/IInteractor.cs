/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An abstract class representing an entity that can interact with interactables.
    /// </summary>
    public abstract class IInteractor : MonoBehaviour
    {
        private IInteractable currentInteractable;

        /// <summary>
        /// Assigns a new current interactable.
        /// </summary>
        /// <param name="interactable">The interactable to assign.</param>
        public virtual void AssignInteractable(IInteractable interactable)
        {
            if (currentInteractable != null)
            {
                UnassignInteractable();
            }

            currentInteractable = interactable;
            currentInteractable.OnAssigned(this);
        }

        /// <summary>
        /// Unassigns the current interactable.
        /// </summary>
        public virtual void UnassignInteractable()
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnUnassigned(this);
                currentInteractable = null;
            }
        }

        /// <summary>
        /// Interacts with the current interactable.
        /// </summary>
        public void Interact()
        {
            currentInteractable?.Interact(this);
        }

        /// <summary>
        /// Returns the currently assigned interactable.
        /// </summary>
        /// <returns>The currently assigned interactable.</returns>
        public IInteractable GetInteractable()
        {
            return currentInteractable;
        }
    }
}
