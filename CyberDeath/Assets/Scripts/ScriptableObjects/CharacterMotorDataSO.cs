/*****************************************************************************
// File Name :         CharacterMotorDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : A data container that stores a Character's movement fields.
*****************************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Character Data/Motor Data", fileName = "New Character Motor Data")]
    public class CharacterMotorDataSO : ScriptableObject
    {
        [InfoBox("You should not be modifying this! Modify the base data instead!", visibleIfMemberName: "IsNotBaseData", infoMessageType: InfoMessageType.Warning)]
        [SerializeField] private bool isBase;
        [HideIf("isBase")]
        [SerializeField] private CharacterMotorDataSO baseData;
        public void SetBaseValues()
        {
            if (isBase)
            {
                Debug.LogWarning("[CharacterMotorDataSO]: Shouldn't be setting base values on a base data set!");
                return;
            }

            this._movementSpeed = baseData.movementSpeed;
            this._rotateSpeed = baseData.rotateSpeed;
            this._jumpHeight = baseData.jumpHeight;
            this._gravity = baseData.gravity;
            this._airControl = baseData.airControl;
            this.maxJumps = baseData.maxJumps;
        }
        private bool IsNotBaseData()
        {
            return !isBase;
        }

        [Tooltip("The character's movement speed.")]
        [SerializeField] private Stat _movementSpeed;
        /// <summary>
        /// The character's movement speed.
        /// </summary>
        public Stat movementSpeed
        {
            get
            {
                return _movementSpeed;
            }
            set
            {
                _movementSpeed = value;
                Debug.Log("New movement speed is " + _movementSpeed.GetStat());
            }
        }

        [Tooltip("The character's speed of rotation.")]
        [SerializeField] private float _rotateSpeed = 5;
        /// <summary>
        /// The character's speed of rotation.
        /// </summary>
        public float rotateSpeed
        {
            get
            {
                return _rotateSpeed;
            }
        }

        [Tooltip("The character's jump height.")]
        [SerializeField] private float _jumpHeight = 2;
        /// <summary>
        /// The character's jump height.
        /// </summary>
        public float jumpHeight
        {
            get
            {
                return _jumpHeight;
            }
        }

        [Tooltip("Gravity adjustment. A larger value means the character experiences" +
            "a stronger gravitational pull.")]
        [SerializeField] private float _gravity = 20;
        /// <summary>
        /// Gravity adjustment. A larger value means the character experiences 
        /// a stronger gravitational pull.
        /// </summary>
        public float gravity
        {
            get
            {
                return _gravity;
            }
        }

        /// <summary>
        /// Sets the gravity to the value provided.
        /// </summary>
        /// <param name="value">The new gravity value.</param>
        public void SetGravity(float value)
        {
            _gravity = value;
        }

        [Tooltip("The amount of air control the character has. A larger value means" +
            "the character has an easier time moving in the air.")]
        [SerializeField] private float _airControl = 5;
        /// <summary>
        /// The amount of air control the character has. A larger value means 
        /// the character has an easier time moving in the air.
        /// </summary>
        public float airControl
        {
            get
            {
                return _airControl;
            }
        }

        [Tooltip("The maximum times this character can jump" +
            "before having to touch the ground again.")]
        [SerializeField] private int maxJumps = 2;
        /// <summary>
        /// The maximum times this character can jump before having to touch the
        /// ground again.
        /// </summary>
        public int MaxJumps
        {
            get
            {
                return maxJumps;
            }
        }

        public void SetMaxJumps(int maxJumps)
        {
            this.maxJumps = maxJumps;
        }
    }
}