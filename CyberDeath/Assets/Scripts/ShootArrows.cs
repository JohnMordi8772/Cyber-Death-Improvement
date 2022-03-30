using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class ShootArrows : MonoBehaviour
    {
        Animator anim;
        [SerializeField] GameObject arrow;
        [SerializeField] Transform player;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(anim.name == "PlayerBow" && anim.GetBool("Fire") == true)
            {
                SpawnArrows();
            }
        }

        void SpawnArrows()
        {
            Debug.Log("What the hell!?!?");
            Instantiate(arrow, player.position + new Vector3(0, 1, 0), player.rotation);
        }
    }
}
