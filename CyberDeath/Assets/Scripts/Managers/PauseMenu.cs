/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class PauseMenu : MonoBehaviour
    {
        private PlayerControls controls;

        [SerializeField] private SelectionArrow selectionArrow;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            controls.UI.Up.started += _ => OnUpPressed();
            controls.UI.Down.started += _ => OnDownPressed();
            controls.UI.Progress.started += _ => Select();

            controls.UI.Up.Enable();
            controls.UI.Down.Enable();
            controls.UI.Progress.Enable();
        }

        private void OnDisable()
        {
            controls.UI.Up.Disable();
            controls.UI.Down.Disable();
            controls.UI.Progress.Disable();
        }
        #endregion



        private void OnUpPressed()
        {
            selectionArrow.Move(SelectionArrow.Direction.UP);
        }

        private void OnDownPressed()
        {
            selectionArrow.Move(SelectionArrow.Direction.DOWN);
        }

        private void Select()
        {
            selectionArrow.Select();
        }
    }
}
