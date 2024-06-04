using System;
using UnityEngine;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        #region Fields

        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float gravity = -9.8f;

        private bool _isGrounded;
        private float _ySpeed;

        #endregion

        #region Private Methods

        private void ApplyGravity()
        {
            _isGrounded = characterController.isGrounded;
            if (_isGrounded)
                _ySpeed = 0;
            else
                _ySpeed += gravity * Time.deltaTime;
        }

        private void Move()
        {
            var deltaX = Input.GetAxis("Horizontal");
            var deltaZ = Input.GetAxis("Vertical");

            characterController.Move(
                transform.TransformDirection(new Vector3(deltaX, _ySpeed , deltaZ)) 
                * (Time.deltaTime * speed));
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            _isGrounded = characterController.isGrounded;
            Move();
        }

        #endregion
    }
}