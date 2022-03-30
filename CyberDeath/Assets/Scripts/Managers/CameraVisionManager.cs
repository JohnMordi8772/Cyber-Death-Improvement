using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class CameraVisionManager : MonoBehaviour
    {
        public Transform obstruction, target, player;
        bool mRNotFound;
        // Start is called before the first frame update
        void Start()
        {
            obstruction = target;
            mRNotFound = false;
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        private void LateUpdate()
        {
            ViewObstructed();
        }

        void ViewObstructed()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, target.position - transform.position, out hit, Vector3.Distance(transform.position, target.position)))
            {
                if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    obstruction = hit.transform;
                    obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                    mRNotFound = false;
                }
                else if(!mRNotFound)
                {
                    try
                    {
                        obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    }
                    catch(MissingComponentException e)
                    {
                        mRNotFound = true;
                    }
                        //if(Vector3.Distance(transform.position, target.position) < 4.5f)
                        //{
                        //    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                        //}
                }
            }
            
        }
    }
}
