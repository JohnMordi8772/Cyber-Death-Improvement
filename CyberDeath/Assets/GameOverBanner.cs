/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoofyGhosts
{
    public class GameOverBanner : MonoBehaviour
    {
        private Animator anim;
        [SerializeField] private Health playerHealth;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            playerHealth.OnDeath += PlayAnim;
        }

        private void OnDisable()
        {
            playerHealth.OnDeath -= PlayAnim;
        }

        private void PlayAnim()
        {
            anim.SetTrigger("GameOver");

            StartCoroutine(ReloadScene());

            IEnumerator ReloadScene()
            {
                yield return new WaitForSeconds(5f);
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            }
        }
    }
}
