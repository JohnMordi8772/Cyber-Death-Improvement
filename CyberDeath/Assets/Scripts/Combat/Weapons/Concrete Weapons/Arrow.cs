using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Arrow : MonoBehaviour
    {
        float dmg = 8;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Spawned");
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 90);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(transform.up * 10 * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Health>().TakeDamage(dmg);
                Destroy(gameObject);
            }
            else if(collision.gameObject.layer != 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
