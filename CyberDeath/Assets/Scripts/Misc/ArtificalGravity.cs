/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Adds an acceleration to the attached Rigidbody.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ArtificalGravity : MonoBehaviour
    {
        [SerializeField] private float force;
        private Rigidbody rb;

        private const float DESTROY_TIME = 2f;

        /// <summary>
        /// Init
        /// </summary>
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Destroy the component after a set time.
        /// </summary>
        private void Start()
        {
            Destroy(this, DESTROY_TIME);
        }

        /// <summary>
        /// Add a continuous force to the rigidbody.
        /// </summary>
        private void FixedUpdate()
        {
            rb.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}