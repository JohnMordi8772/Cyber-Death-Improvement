/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class MenuSliderSelectable : MonoBehaviour, IMenuSelectable
    {
        private PlayerControls controls;
        [SerializeField] private Slider slider;
        private Image img;
        [SerializeField] private float sensitivity = 20f;

        private bool movingLeft;
        private bool movingRight;

        private void Awake()
        {
            controls = new PlayerControls();
            img = GetComponent<Image>();
        }

        #region -- // Event Handling // --
        void OnEnable()
        {
            controls.UI.Left.performed += _ => movingLeft = true;
            controls.UI.Right.performed += _ => movingRight = true;

            controls.UI.Right.canceled += _ => movingRight = false;
            controls.UI.Left.canceled += _ => movingLeft = false;
        }

        void OnDisable()
        {
            controls.UI.Left.Disable();
            controls.UI.Right.Disable();
        }
        #endregion


        private void Start()
        {
            UnSelect();
        }

        private void Update()
        {
            if (movingRight)
            {
                MoveRight();
            }
            else if (movingLeft)
            {
                MoveLeft();
            }
        }


        public RectTransform GetRectTransform()
        {
            return transform as RectTransform;
        }

        public void Select()
        {
            img.enabled = true;
            controls.UI.Left.Enable();
            controls.UI.Right.Enable();
        }

        public void UnSelect()
        {
            img.enabled = false;
            controls.UI.Left.Disable();
            controls.UI.Right.Disable();
        }

        private void MoveLeft()
        {
            slider.value -= sensitivity * Time.unscaledDeltaTime;
        }

        private void MoveRight()
        {
            slider.value += sensitivity * Time.unscaledDeltaTime;
        }
    }
}
