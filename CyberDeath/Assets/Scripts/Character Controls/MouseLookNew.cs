using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class MouseLookNew : MonoBehaviour
    {
        private Vector3 mousePos;
        private Quaternion newRot;

        private PlayerControls newPC;

        // Start is called before the first frame update
        void Start()
        {
            newPC = new PlayerControls();
        }

        // Update is called once per frame
        void Update()
        {
            mousePos = newPC.Player.MouseMove.ReadValue<Vector2>();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            print(mousePos);
           
            newRot = transform.rotation;
            //newRot.y = Mathf.Atan(Vector3.Distance(transform.position, mousePos));
            transform.rotation = newRot;  
        }
    }
}
