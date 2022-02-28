/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public abstract class PlayerModule : Module
    {
        [SerializeField] protected CharacterMotorDataSO motorData;
    }
}