using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class EnemyRanged : IWeapon
    {
        [SerializeField] GameObject bullet;
        GameObject player;
        Transform parentTransform;
        protected override void FireWeapon()
        {
            Instantiate(bullet, gameObject.transform.position, new Quaternion(0,0,0,0));
        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            parentTransform = this.transform.root;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
