using UnityEngine;

public class GestionMusica : MonoBehaviour
{
    public AudioSource fuenteAudio;  // Fuente del audio
    public AudioClip[] pistas;  // Arreglo con las pistas de música
    private int pistaActual = 0;  // Índice de la pista actual

    void Start()
    {
        // Intentar obtener una fuente de audio del mismo objeto si no se provee una
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();

        // Cargar la primera pista de música
        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir la siguiente pista de música
    public void SiguientePista()
    {
        pistaActual++;
        if (pistaActual >= pistas.Length)
            pistaActual = 0;  // Volver al inicio

        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir la pista anterior de música
    public void PistaAnterior()
    {
        pistaActual--;
        if (pistaActual < 0)
            pistaActual = pistas.Length - 1;  // Volver al final

        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir una pista de música específica
    public void ReproducirPista(int indice)
    {
        if (indice < 0 || indice >= pistas.Length) return;  // Índice fuera de rango

        pistaActual = indice;
        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Detener la reproducción de la música
    public void DetenerMusica()
    {
        fuenteAudio.Stop();
    }

    // Ajustar el volumen de la música
    public void AjustarVolumen(float volumen)
    {
        fuenteAudio.volume = volumen;
    }

    // Pausar y reanudar la reproducción de la música
    public void PausarReanudarMusica()
    {
        if (fuenteAudio.isPlaying)
            fuenteAudio.Pause();
        else
            fuenteAudio.Play();
    }
}
