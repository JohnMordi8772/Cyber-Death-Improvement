using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Bow : IWeapon
    {
        [SerializeField] GameObject arrow;
        [SerializeField] Transform player;
        protected override void FireWeapon()
        {
            Instantiate(arrow, player.position, player.rotation);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
