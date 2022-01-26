/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace GoofyGhosts
{
    public class PlayerAttackStateAnimBehaviour : StateMachineBehaviour
    {
        public static UnityAction OnStateEnterAction;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateEnterAction?.Invoke();
        }
    }
}
