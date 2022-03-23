/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GoofyGhosts
{
    [RequireComponent(typeof(CharacterMotor))]
    public class DashAbility : IAbility
    {
        [SerializeField] private LayerMask whatIsEnemy;
        [SerializeField] private GameObject dashVFX;

        [Header("SFX")]
        [SerializeField] private AudioClipChannelSO sfxChannel;
        [SerializeField] private AudioClipSO dashSFX;

        private CharacterMotor motor;
        private DashAbilityData dashData;
        private Collider col;

        private void Awake()
        {
            motor = GetComponent<CharacterMotor>();
            col = GetComponent<Collider>();
            dashData = base.data as DashAbilityData;
        }

        /// <summary>
        /// Activates the ability's unique functionality.
        /// </summary>
        protected override void ActivateAbility()
        {
            sfxChannel.RaiseEvent(dashSFX);
            motor.AddImpact(dashData.DashForce.GetStat(), dashData.DashDuration);
            StartCoroutine(Cast());
        }

        /// <summary>
        /// Performs a sphere cast and knocks back + damages enemies hit.
        /// </summary>
        private IEnumerator Cast()
        {
            dashVFX.SetActive(true);

            float currentTime = 0f;
            List<GameObject> hitEnemies = new List<GameObject>();

            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);

            while (currentTime < dashData.DashDuration)
            {
                currentTime += Time.deltaTime;

                foreach (Collider col in Physics.OverlapSphere(transform.position, dashData.KnockbackRange, whatIsEnemy))
                {
                    if (!hitEnemies.Contains(col.gameObject))
                    {
                        print("Hit " + col.gameObject.name);
                        hitEnemies.Add(col.gameObject);
                        //col.gameObject.GetComponent<CharacterMotor>().AddImpact(-col.transform.forward * dashData.EnemyKnockBack, 1f);

                        //EnemyStateManager manager = col.GetComponent<EnemyStateManager>();

                        //manager.SwapState<EnemyAttackedState>();
                        //manager.OnAttacked(dashData.DashDamage);
                    }
                }

                yield return null;
            }


            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);

            yield return new WaitForSeconds(0.3f);
            dashVFX.SetActive(false);
        }
    }
}