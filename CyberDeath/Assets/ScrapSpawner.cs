/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class ScrapSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject scrapPrefab;
        [SerializeField] private IntChannelSO waveChannel;

        private void OnEnable()
        {
            waveChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= OnWaveChange;
        }

        private void OnWaveChange(int waveNum)
        {
            if (waveNum == -1)
            {
                StopAllCoroutines();
            }
            else
            {
                StartCoroutine(SpawnScrap());
            }
        }

        private IEnumerator SpawnScrap()
        {
            while(true)
            {
                yield return new WaitForSeconds(Random.Range(5, 11));
                Instantiate(scrapPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}