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
        private Vector3 mousePos;
        private Quaternion newRot;

        private PlayerControls newPC;
        public static bool scriptEnabled;

        // Start is called before the first frame update
        void Start()
        {
            newPC = new PlayerControls();
            scriptEnabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos.z = mousePos.y;
            mousePos.y = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //print(mousePos);
            mousePos.z = -(mousePos.y + 330);
            mousePos.y = transform.position.y;
            print(mousePos);
            transform.LookAt(mousePos);

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
