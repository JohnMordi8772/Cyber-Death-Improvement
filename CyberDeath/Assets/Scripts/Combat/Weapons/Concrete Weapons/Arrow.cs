using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
    public class Arrow : MonoBehaviour
    {
        private Vector2 mousePos;
        private Vector3 newRot, targetDirection, newDirection;
        Vector2 screenCenter;
        float dmg = 8;
        // Start is called before the first frame update
        void Awake()
        {
            transform.Rotate(90, 0, 0);
            //transform.rotation = Quaternion.Euler(90, 0, 0);
            //Debug.Log("Spawned");
            //screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            //mousePos = Mouse.current.position.ReadValue();
            //Vector2 direction = (mousePos - screenCenter).normalized;
            //float angle = (Mathf.Atan2(-direction.y, direction.x)) * Mathf.Rad2Deg;
            //newRot = new Vector3(0, angle, 0);
            //transform.rotation = Quaternion.Euler(0, angle, 0);

            //Ray cameraRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            //Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            //float rayLength;

            //if(groundPlane.Raycast(cameraRay, out rayLength))
            //{
            //    Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            //    transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            //}
        }

        // Update is called once per frame
        void Update()
        {
            Debug.DrawRay(transform.position, transform.forward);
            transform.Translate(Vector3.up * 50 * Time.deltaTime);
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
                other.gameObject.GetComponent<Health>().TakeDamage(dmg);
                Destroy(gameObject);
            }
            else if (other.gameObject.layer != 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
