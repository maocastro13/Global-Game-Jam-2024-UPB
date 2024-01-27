using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 100f;

    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotationY -= mouseX;
        rotationY = Mathf.Clamp(rotationY, -180f, 1800f);

        transform.localRotation = Quaternion.Euler(0, -rotationY, 0);
        transform.position = player.transform.position;
    }
}
