using UnityEngine;

public class GestionEfectosSonido : MonoBehaviour
{
    public AudioSource fuenteAudio;  // Fuente del audio
    public AudioClip[] efectos;  // Arreglo con los efectos de sonido

    void Start()
    {
        // Intentar obtener una fuente de audio del mismo objeto si no se provee una
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();
    }

    // Reproducir un efecto de sonido específico
    public void ReproducirEfecto(int indice)
    {
        if (indice < 0 || indice >= efectos.Length) return;  // Índice fuera de rango

        fuenteAudio.clip = efectos[indice];
        fuenteAudio.Play();
    }
    // Detener la reproducción del efecto de sonido
    public void DetenerEfecto()
    {
        fuenteAudio.Stop();
    }

    // Ajustar el volumen de los efectos de sonido
    public void AjustarVolumen(float volumen)
    {
        fuenteAudio.volume = volumen;
    }

    // Ajustar el tono de los efectos de sonido
    public void AjustarTono(float tono)
    {
        fuenteAudio.pitch = tono;
    }

    // Pausar y reanudar la reproducción de los efectos de sonido
    public void PausarReanudarEfecto()
    {
        if (fuenteAudio.isPlaying)
            fuenteAudio.Pause();
        else
            fuenteAudio.Play();
    }
}
