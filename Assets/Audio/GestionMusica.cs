using UnityEngine;

public class GestionMusica : MonoBehaviour
{
    public AudioSource fuenteAudio;  // Fuente del audio
    public AudioClip[] pistas;  // Arreglo con las pistas de m�sica
    private int pistaActual = 0;  // �ndice de la pista actual

    void Start()
    {
        // Intentar obtener una fuente de audio del mismo objeto si no se provee una
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();

        // Cargar la primera pista de m�sica
        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir la siguiente pista de m�sica
    public void SiguientePista()
    {
        pistaActual++;
        if (pistaActual >= pistas.Length)
            pistaActual = 0;  // Volver al inicio

        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir la pista anterior de m�sica
    public void PistaAnterior()
    {
        pistaActual--;
        if (pistaActual < 0)
            pistaActual = pistas.Length - 1;  // Volver al final

        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Reproducir una pista de m�sica espec�fica
    public void ReproducirPista(int indice)
    {
        if (indice < 0 || indice >= pistas.Length) return;  // �ndice fuera de rango

        pistaActual = indice;
        fuenteAudio.clip = pistas[pistaActual];
        fuenteAudio.Play();
    }

    // Detener la reproducci�n de la m�sica
    public void DetenerMusica()
    {
        fuenteAudio.Stop();
    }

    // Ajustar el volumen de la m�sica
    public void AjustarVolumen(float volumen)
    {
        fuenteAudio.volume = volumen;
    }

    // Pausar y reanudar la reproducci�n de la m�sica
    public void PausarReanudarMusica()
    {
        if (fuenteAudio.isPlaying)
            fuenteAudio.Pause();
        else
            fuenteAudio.Play();
    }
}
