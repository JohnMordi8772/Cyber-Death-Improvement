using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace GoofyGhosts
{
    public class MouseLookNew : MonoBehaviour
    {
        private Vector2 mousePos;
        private Quaternion newRot;
        Vector2 screenCenter;

        private PlayerControls newPC;
        public static bool scriptEnabled;

        // Start is called before the first frame update
        void Start()
        {
            newPC = new PlayerControls();
            scriptEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            
            Cursor.lockState = CursorLockMode.Confined;
            
        }

        // Update is called once per frame
        void Update()
        {
            screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            mousePos = Mouse.current.position.ReadValue();
            Vector2 direction = (mousePos - screenCenter).normalized;
            float angle = (Mathf.Atan2(-direction.y, direction.x)) * Mathf.Rad2Deg;
            print(direction);
            transform.rotation = Quaternion.Euler(0, angle+90, 0);
            ////mousePos.z = mousePos.y;
            ////mousePos.y = 0;
            //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //mousePos.z = -(mousePos.y + 330);
            //mousePos.y = transform.position.y;
            //print(mousePos);
            //transform.LookAt(mousePos);

            /*
            newRot = transform.rotation;
            newRot.y = Mathf.Atan(Vector3.Distance(transform.position, mousePos));
            transform.rotation = newRot; 
            */
        }

        public static void UseThis(TextMeshProUGUI text)
        {
            scriptEnabled = !scriptEnabled;
            if(scriptEnabled)
            {
                text.color = Color.green;
            }
            else
            {
                text.color = Color.red;
            }
        }
    }
}
