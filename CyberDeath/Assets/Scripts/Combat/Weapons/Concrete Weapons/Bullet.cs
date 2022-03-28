using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Bullet : MonoBehaviour
    {

        public Transform target;
        Vector3 newDirection, targetDirection;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 targetPosition = target.position + new Vector3(0, 1.8f, 0);

            StartCoroutine(EndBullet());

            targetDirection = (targetPosition - transform.position).normalized * 10;

            newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 2f, 0.0f);
        }

        void Update()
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            Debug.DrawRay(transform.position, newDirection, Color.green);
            transform.Translate(new Vector3(targetDirection.x, targetDirection.y, targetDirection.z) * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                other.GetComponent<Health>().TakeDamage(5f);
                Destroy(gameObject);
            }
            else if(other.tag != "Enemy")
            {
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
