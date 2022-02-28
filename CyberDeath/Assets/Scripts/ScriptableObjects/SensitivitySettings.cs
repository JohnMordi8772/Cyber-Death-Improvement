/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/04/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Holds float values to adjust sensitivity.
    /// </summary>
    [CreateAssetMenu(menuName = "Settings/Sensitivity Settings", fileName = "New Sensitivity Settings")]
    public class SensitivitySettings : ScriptableObject
    {
        /// <summary>
        /// The horizontal look rotation sensitivity.
        /// </summary>
        [Min(0)]public float yawSensitivity;

        /// <summary>
        /// The vertical look rotation sensitivity.
        /// </summary>
        [Min(0)]public float pitchSensitivity;

        /// <summary>
        /// True if the vertical look rotation should be inverted.
        /// </summary>
        public bool inversePitch;

        /// <summary>
        /// True if the horizontal look rotation should be inverted.
        /// </summary>
        public bool inverseYaw;
    }
}