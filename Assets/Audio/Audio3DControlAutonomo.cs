using UnityEngine;

public class Audio3DControlAutonomo : MonoBehaviour
{
    public AudioSource fuenteAudio;  // La fuente del audio
    public GameObject jugador;  // El objeto del jugador
    public float velocidad = 1.0f;  // La velocidad a la que se mover� la fuente de audio

    void Start()
    {
        // Si no se provee una fuente de audio, se intentar� obtener una del mismo objeto
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Obtener la posici�n del jugador
        Vector3 posicionJugador = jugador.transform.position;

        // Calcular la direcci�n desde la posici�n actual de la fuente de audio hacia la posici�n del jugador
        Vector3 direccion = posicionJugador - fuenteAudio.transform.position;

        // Normalizar la direcci�n para obtener un vector de direcci�n unitario
        direccion.Normalize();

        // Multiplicar la direcci�n por la velocidad para obtener el desplazamiento en cada fotograma
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

        // Mover la fuente de audio en la direcci�n calculada
        fuenteAudio.transform.Translate(desplazamiento);
    }
}
