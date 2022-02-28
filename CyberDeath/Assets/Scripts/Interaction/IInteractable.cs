/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// An entity that can be interacted with.
    /// </summary>
    public interface IInteractable
    {
        void Interact(IInteractor interactor);
        void OnAssigned(IInteractor interactor);
        void OnUnassigned(IInteractor interactor);
    }
}