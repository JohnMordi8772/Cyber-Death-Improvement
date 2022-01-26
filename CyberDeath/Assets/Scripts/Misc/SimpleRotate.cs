/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class SimpleRotate : MonoBehaviour
    {
        [Tooltip("The speed at which the scrap rotates.")]
        [SerializeField] private float rotateSpeed;

        /// <summary>
        /// Rotates the GameObject.
        /// </summary>
        private void Update()
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
}