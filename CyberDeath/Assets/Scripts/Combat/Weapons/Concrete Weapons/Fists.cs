/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class Fists : IWeapon
    {
        [SerializeField] private float attackRange = 6f;
        [SerializeField] private LayerMask whatIsTarget;
        private AudioSourceInstance audioSource;
        [SerializeField] private AudioClipSO attackClip;

        protected override void Awake()
        {
            base.Awake();
            audioSource = new AudioSourceInstance(attackClip, gameObject);
        }

        protected override void FireWeapon()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, attackRange, whatIsTarget))
            {
                IDamageable target = hit.transform.GetComponent<IDamageable>();
                if (target == null)
                {
                    print("Target is null??");
                }
                else
                {
                    target.TakeDamage(WeaponDamage);
                    audioSource.Play();
                }
            }
        }
    }
}
