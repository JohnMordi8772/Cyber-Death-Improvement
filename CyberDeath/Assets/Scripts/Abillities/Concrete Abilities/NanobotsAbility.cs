using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class NanobotsAbility : IAbility
    {
        [SerializeField] Health playerHealth;
        [SerializeField] HealthData playerHealthData;
        bool cooldownBool;

        protected override void ActivateAbility()
        {
            if (playerHealthData.currentHealth <= playerHealthData.maxHealth.GetStat() - 30)
                playerHealth.TakeDamage(-30);
            else
                playerHealth.TakeDamage(playerHealthData.currentHealth - playerHealthData.maxHealth.GetStat());
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
