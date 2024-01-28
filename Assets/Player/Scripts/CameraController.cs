using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 100f;

    private float rotationY = 0f;
    public bool isFall = false;

    public Transform playerT;
    public float followSpeed = 10f;
    public float maxFOV = 90f;
    private Camera cam;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        playerT = player.transform;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotationY -= mouseX;
        rotationY = Mathf.Clamp(rotationY, -180f, 1800f);

        transform.localRotation = Quaternion.Euler(0, -rotationY, 0);
        transform.position = player.transform.position;

        if (isFall)
        {
            StartCoroutine(CameraShake(1, 1));
            
        }
        else
        {
            // Restablecer el FOV
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, Time.deltaTime);
        }
    }

    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = cam.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cam.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        // Seguir al jugador
        Vector3 newPosition = new Vector3(playerT.position.x, playerT.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);

        // Incrementar el FOV
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, maxFOV, Time.deltaTime);
        

        cam.transform.localPosition = originalPos;
        isFall = false;
    }
}
