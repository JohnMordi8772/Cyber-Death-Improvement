/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/
using UnityEngine;
using System.Collections;

namespace GoofyGhosts
{
    /// <summary>
    /// The collectable currency in the game.
    /// </summary>
    public class CoilScrap : MonoBehaviour
    {
        [SerializeField] private IntChannelSO waveChannel;
        public GameObject scrapVFX;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3f);
            //HideUtility.HideGameObject(gameObject);
        }

        private void OnEnable()
        {
            waveChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= OnWaveChange;
        }

        /// <summary>
        /// Adds scrap to the player's account.
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ScrapCounter.AddCoilScrap();
                print("Scrap collected");
                Instantiate(scrapVFX, new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z), transform.rotation);

                Destroy(gameObject);
            }
        }

        private void OnWaveChange(int waveNum)
        {
            if (waveNum == -1)
                return;

            //HideUtility.HideGameObject(gameObject);
        }
    }
}