/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class DebugManager : MonoBehaviour
    {
        private PlayerControls controls;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            controls.Debug.RewardScrap.started += _ => RewardScrap();
            controls.Debug.Enable();
        }

        private void OnDisable()
        {
            controls.Debug.Disable();
        }
        #endregion

        private void RewardScrap()
        {
            ScrapCounter.AddScrap("");
        }
    }
}