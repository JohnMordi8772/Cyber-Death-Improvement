using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Bullet : MonoBehaviour
    {

        public Transform target;
        Vector3 newDirection;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 targetPosition = target.position + new Vector3(0, 2.27f, 0);
            //gameObject.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, GameObject.Find("Player").transform.position - transform.position, 1, 1));

            //StartCoroutine(EndBullet());
            // Determine which direction to rotate towards
            Vector3 targetDirection = targetPosition - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = 2;

            // Rotate the forward vector towards the target direction by one step
            newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            //transform.rotation = Quaternion.LookRotation(newDirection);
        }

        // Angular speed in radians per sec.
        public float speed = 1.0f;

        void Update()
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            Debug.DrawRay(transform.position, newDirection, Color.green);
            transform.Translate(newDirection * 5 * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                other.GetComponent<Health>().TakeDamage(5f);
                Destroy(gameObject);
            }
        }

        IEnumerator EndBullet()
        {
            yield return new WaitForSeconds(7);
            Destroy(gameObject);
        }
    }
}
