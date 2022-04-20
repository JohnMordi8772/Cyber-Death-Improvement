/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/12/2021
*******************************************************************/
using UnityEngine.Events;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// A component which gives a GameObject health.
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] private bool destroyOnDeath = false;
        public UnityAction<HealthData> OnDamageTaken;
        public UnityAction OnDeath;
        [SerializeField] private bool healthInstance;
        [SerializeField] private HealthData data;
        [SerializeField] private VoidChannelSO deathChannel;
        [SerializeField] private HealthDataChannelSO takeDamageChannel;
        [SerializeField] private Armor armor;
        [SerializeField] private ParticleSystem hitParticles;
        private bool dead;
        public bool isEnemy;
        public int critChance;
        private bool critted = false;
        public ParticleSystem critParticles;

        private void Start()
        {
            data.Init();
            if(armor == null)
            {
                armor = ScriptableObject.CreateInstance<Armor>();
                armor.CurrentArmor = new Stat("Armor", 1f);
            }
            else
            {
                armor.Init();
            }

            if (healthInstance)
            {
                HealthData tempData = ScriptableObject.CreateInstance<HealthData>();
                tempData.Init(data);
                data = tempData;
            }

            takeDamageChannel?.RaiseEvent(data);
            critChance = GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance;
        }

        public void TakeDamage(float amnt)
        {
            if (dead)
                return;

            if (isEnemy)
            {
                int chance = Random.Range(1, 100);
                if (chance < critChance)
                {
                    amnt *= 1.5f;
                    critted = true;
                }
            }

            if (amnt < 0)
            {
                IncreaseHealth(-amnt);
                return;
            }

            data.currentHealth -= (amnt * (1 - (armor.GetArmorLevel() * 0.05f)));
            OnDamageTaken?.Invoke(data);
            takeDamageChannel?.RaiseEvent(data);

            if (data.currentHealth <= 0)
            {
                dead = true;
                OnDeath?.Invoke();
                deathChannel?.RaiseEvent();

                if (hitParticles != null)
                {
                    if (critted)
                    {
                        critParticles.Play();
                    }
                    else
                    {
                        hitParticles.transform.parent = null;
                        hitParticles.Play();
                    }
                }

                if (destroyOnDeath)
                    Destroy(gameObject);
            }
            else if (hitParticles != null)
            {
                if (critted)
                {
                    critParticles.Play();
                    critted = false;
                }
                else
                {
                    hitParticles.Play();
                }
            }
        }

        public void TakeDamage(float amnt, bool behind)
        {
            if (dead)
                return;

            if (isEnemy)
            {
                critChance = GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance;
                int chance = Random.Range(1, 100);
                if (chance < critChance || behind)
                {
                    amnt *= 1.5f;
                    critted = true;
                }
            }

            if (amnt < 0)
            {
                IncreaseHealth(-amnt);
                return;
            }

            data.currentHealth -= (amnt * (1 - (armor.GetArmorLevel() * 0.05f)));
            OnDamageTaken?.Invoke(data);
            takeDamageChannel?.RaiseEvent(data);

            if (data.currentHealth <= 0)
            {
                dead = true;
                OnDeath?.Invoke();
                deathChannel?.RaiseEvent();

                if (hitParticles != null)
                {
                    if (critted)
                    {
                        critParticles.Play();
                    }
                    else
                    {
                        hitParticles.transform.parent = null;
                        hitParticles.Play();
                    }
                }

                if (destroyOnDeath)
                    Destroy(gameObject);
            }
            else if (hitParticles != null)
            {
                if (critted)
                {
                    critParticles.Play();
                    critted = false;
                }
                else
                {
                    hitParticles.Play();
                }
            }
        }

        public void IncreaseHealth(float amnt)
        {
            if (amnt < 0)
            {
                TakeDamage(-amnt);
                return;
            }

            data.currentHealth += amnt;
            data.currentHealth = Mathf.Clamp(data.currentHealth, 0, data.maxHealth.GetStat());
            OnDamageTaken?.Invoke(data);
            takeDamageChannel?.RaiseEvent(data);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ground Slam")
            {
                TakeDamage(60);
            }
        }
    }
}