/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 12/4/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoofyGhosts
{
    public class MenuButtonSelectable : MonoBehaviour, IMenuSelectable
    {
        [SerializeField] private UnityEvent OnSelected;

        public RectTransform GetRectTransform()
        {
            return transform as RectTransform;
        }

        public void Select()
        {
            OnSelected?.Invoke();
        }

        public void UnSelect()
        {

        }
    }
}
