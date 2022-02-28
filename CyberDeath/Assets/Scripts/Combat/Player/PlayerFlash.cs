/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 12/1/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class PlayerFlash : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer rend;
        [SerializeField] private int[] materialIndices;
        private bool flashing;

        public void StartFlash()
        {
            if (flashing)
                return;

            flashing = true;
            for (int i = 0; i < materialIndices.Length; ++i)
            {
                StartCoroutine(Flash(rend.materials[materialIndices[i]]));
            }
        }

        private IEnumerator Flash(Material mat)
        {
            const float TIME_BETWEEN_FLASHES = 0.10f;

            Color originalColor = mat.color;
            Color originalEmission = mat.GetColor("_EmissionColor");

            Color flashColor = Color.red;
            Color emissionColor = Color.red;
            const float EMISSION_INTENSITY = 5f;

            while(flashing)
            {
                mat.color = flashColor;
                mat.SetColor("_EmissionColor", emissionColor * EMISSION_INTENSITY);
                yield return new WaitForSeconds(TIME_BETWEEN_FLASHES);
                mat.color = originalColor;
                mat.SetColor("_EmissionColor", originalEmission);
                yield return new WaitForSeconds(TIME_BETWEEN_FLASHES);
            }

            mat.color = originalColor;
            mat.SetColor("_EmissionColor", originalEmission);
        }

        public void EndFlash()
        {
            flashing = false;
        }
    }
}
