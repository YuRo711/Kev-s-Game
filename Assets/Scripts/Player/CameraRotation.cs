using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraRotation : MonoBehaviour
{
    #region Fields

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerTransform;

    private float _rotationX;

    #endregion

    #region Private Methods

    private void ProcessMouseMovement()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _rotationX = Math.Clamp(_rotationX - mouseY, -45f, 45f);
        
        playerTransform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(_rotationX, mouseX, 0);
    }

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ProcessMouseMovement();
    }

    #endregion
}
