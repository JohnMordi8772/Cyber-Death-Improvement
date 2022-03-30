using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class SelectFirst : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            GetComponent<Button>().Select();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
