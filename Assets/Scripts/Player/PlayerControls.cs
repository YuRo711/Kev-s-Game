using System;
using UnityEngine;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        #region Fields

        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 10f;

        #endregion

        #region Private Methods

        private void Move()
        {
            var deltaX = Input.GetAxis("Horizontal");
            var deltaZ = Input.GetAxis("Vertical");

            var moveVector = transform.right * deltaX + transform.forward * deltaZ;

            characterController.Move(moveVector * (Time.deltaTime * speed));
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            Move();
        }

        #endregion
    }
}