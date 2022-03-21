using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class ControlsPanel : MonoBehaviour
    {
        public GameObject controlsPnl;
        
        // Start is called before the first frame update
        void Start()
        {
            controlsPnl.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                controlsPnl.SetActive(false);
            }
        }

        public void OnClick()
        {
            controlsPnl.SetActive(false);
        }
    }
}
