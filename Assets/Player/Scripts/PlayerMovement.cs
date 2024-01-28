using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// 2024-01-27 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpSpeed = 8f;  // velocidad de salto
    public CameraController cameraController;  // referencia al script de la c�mara

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity;  // velocidad vertical del jugador

    private PlayerStamina playerStamina;

    public bool isPlayerStop = false;

    void Start()
    {
        playerStamina = GameObject.Find("Player").GetComponent<PlayerStamina>();
        characterController = GetComponent<CharacterController>();
    }

    float timer = 0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        timer += Time.deltaTime;

        if (horizontalInput == 0 && verticalInput == 0)
        {
            isPlayerStop = true;
            GameObject.Find("AudioManager").GetComponent<GestionSonidosAmbientales>().fuenteAudio.Pause();
        }
        else
        {
            isPlayerStop = false;

            if(timer > 2.5f)
            {
                Debug.Log("Entre");
                GameObject.Find("AudioManager").GetComponent<GestionSonidosAmbientales>().OneShotClipSteeps();
                timer = 0f;
            }
            
        }

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (playerStamina.currentStamina > 1)
            {
                Debug.Log(playerStamina.currentStamina);
                playerStamina.currentStamina -= 0.1f;
            }
        }
        else
        {
            if(playerStamina.currentStamina < 100f)
            {
                Debug.Log(playerStamina.currentStamina);
                runSpeed = 10f;
                playerStamina.currentStamina += 0.5f;
            }
        }

        // Calcula la direcci�n de movimiento bas�ndose en la rotaci�n de la c�mara
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = cameraController.transform.rotation * moveDirection;
        moveDirection *= speed;

        // Maneja el salto
        if (characterController.isGrounded)  // Si el personaje est� en el suelo
        {
            if (Input.GetButtonDown("Jump"))  // Si el jugador presiona el bot�n de salto
            {
                verticalVelocity = jumpSpeed;  // establece la velocidad vertical al valor de velocidad de salto
            }
        }
        else
        {
            // si el personaje no est� en el suelo, aplica la gravedad
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        // a�ade la velocidad vertical a la direcci�n de movimiento
        moveDirection.y = verticalVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().Die();
    }

    IEnumerator WaitClip()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("AudioManager").GetComponent<GestionSonidosAmbientales>().ReproducirSonido(0);
    }
}

