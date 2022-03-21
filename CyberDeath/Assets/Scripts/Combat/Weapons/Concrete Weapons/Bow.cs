using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class Bow : IWeapon
    {
        [SerializeField] GameObject arrow;
        [SerializeField] Transform player;
        PlayerControls controls;

        protected override void FireWeapon()
        {
            Debug.Log("What the hell!?!?");
            Instantiate(arrow, player.position + new Vector3(0, 1, 0), player.rotation);
        }
    }
}
