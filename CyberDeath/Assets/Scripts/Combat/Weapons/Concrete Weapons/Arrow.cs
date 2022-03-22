using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
    public class Arrow : MonoBehaviour
    {
        private Vector2 mousePos;
        private Quaternion newRot;
        Vector2 screenCenter;
        float dmg = 8;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Spawned");
            //screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            //mousePos = Mouse.current.position.ReadValue();
            //Vector2 direction = (mousePos - screenCenter).normalized;
            //float angle = (Mathf.Atan2(-direction.y, direction.x)) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, angle-90, 0);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(transform.forward * 10 * Time.deltaTime);
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Health>().TakeDamage(dmg);
                Destroy(gameObject);
            }
            else if (other.gameObject.layer != 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
