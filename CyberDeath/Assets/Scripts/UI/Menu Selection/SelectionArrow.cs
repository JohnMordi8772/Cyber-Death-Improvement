/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    [RequireComponent(typeof(RectTransform))]
    public class SelectionArrow : MonoBehaviour
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private new RectTransform transform;

        [SerializeField] private GameObject selectionParent;
        private IMenuSelectable[] selectables;
        private int NumSelectables
        {
            get
            {
                return selectables.Length;
            }
        }
        private IMenuSelectable CurrentSelection
        {
            get
            {
                return selectables[selectionIndex];
            }
        }
        private int selectionIndex;

        [SerializeField] private Vector2 offset;


        private void Awake()
        {
            transform = gameObject.transform as RectTransform;
            selectables = selectionParent.GetComponentsInChildren<IMenuSelectable>();
        }


        public void Move(Direction dir)
        {
            int newSelectionIndex = selectionIndex;

            switch (dir)
            {
                case Direction.UP:
                    --newSelectionIndex;
                    break;
                case Direction.DOWN:
                    ++newSelectionIndex;
                    break;
            }

            Move(newSelectionIndex);
        }

        private void Move(int newSelectionIndex)
        {
            if (newSelectionIndex >= NumSelectables || newSelectionIndex < 0)
            {
                newSelectionIndex = selectionIndex;
            }
            else if (newSelectionIndex != selectionIndex)
            {
                selectables[selectionIndex].UnSelect();
            }

            selectionIndex = newSelectionIndex;


            RectTransform selection = selectables[selectionIndex].GetRectTransform();

            Vector2 anchoredPos = selection.anchoredPosition;
            anchoredPos.x += offset.x;
            anchoredPos.y += offset.y;

            transform.anchoredPosition = anchoredPos;
        }

        public void Select()
        {
            CurrentSelection.Select();
        }
    }
}