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
    public interface IMenuSelectable
    {
        void Select();
        RectTransform GetRectTransform();
        void UnSelect();
    }
}
