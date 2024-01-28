using UnityEngine;

public class Audio3DControlAutonomo : MonoBehaviour
{
    public AudioSource fuenteAudio;  // La fuente del audio
    public GameObject jugador;  // El objeto del jugador
    public float velocidad = 1.0f;  // La velocidad a la que se moverá la fuente de audio

    void Start()
    {
        // Si no se provee una fuente de audio, se intentará obtener una del mismo objeto
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Obtener la posición del jugador
        Vector3 posicionJugador = jugador.transform.position;

        // Calcular la dirección desde la posición actual de la fuente de audio hacia la posición del jugador
        Vector3 direccion = posicionJugador - fuenteAudio.transform.position;

        // Normalizar la dirección para obtener un vector de dirección unitario
        direccion.Normalize();

        // Multiplicar la dirección por la velocidad para obtener el desplazamiento en cada fotograma
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

        // Mover la fuente de audio en la dirección calculada
        fuenteAudio.transform.Translate(desplazamiento);
    }
}
