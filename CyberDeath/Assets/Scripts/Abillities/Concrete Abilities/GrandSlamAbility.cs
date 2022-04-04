using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class GrandSlamAbility : IAbility
    {
        [SerializeField] private LayerMask whatIsEnemy;

        private SlamAbilityData slamData;
        private CharacterMotor motor;
        private Collider col;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        protected override void ActivateAbility()
        {
            motor.AddImpact(slamData.DashForce.GetStat(), 1);
            StartCoroutine(Cast());
        }


        private IEnumerator Cast()
        {
            

         
            List<GameObject> hitEnemies = new List<GameObject>();

            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);

            

                foreach (Collider col in Physics.OverlapSphere(transform.position, slamData.KnockbackRange, whatIsEnemy))
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

           


            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);

            yield return new WaitForSeconds(0.3f);
           
        }
    }
}
