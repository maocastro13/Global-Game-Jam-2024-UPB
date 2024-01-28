using UnityEngine;

public class GestionSonidosAmbientales : MonoBehaviour
{
    public AudioSource fuenteAudio;  // Fuente del audio
    public AudioClip[] sonidosAmbientales;  // Arreglo con los sonidos ambientales
    private int sonidoActual = 0;  // Índice del sonido ambiental actual

    void Start()
    {
        // Intentar obtener una fuente de audio del mismo objeto si no se provee una
        if (fuenteAudio == null)
            fuenteAudio = GetComponent<AudioSource>();

        // Configurar la fuente de audio para reproducir en bucle
        fuenteAudio.loop = true;

        // Cargar el primer sonido ambiental
        fuenteAudio.clip = sonidosAmbientales[sonidoActual];
        fuenteAudio.Play();
    }

    // Cambiar al siguiente sonido ambiental
    public void SiguienteSonido()
    {
        sonidoActual++;
        if (sonidoActual >= sonidosAmbientales.Length)
            sonidoActual = 0;  // Volver al inicio

        fuenteAudio.clip = sonidosAmbientales[sonidoActual];
        fuenteAudio.Play();
    }

    // Cambiar al sonido ambiental anterior
    public void SonidoAnterior()
    {
        sonidoActual--;
        if (sonidoActual < 0)
            sonidoActual = sonidosAmbientales.Length - 1;  // Volver al final

        fuenteAudio.clip = sonidosAmbientales[sonidoActual];
        fuenteAudio.Play();
    }

    // Reproducir un sonido ambiental específico
    public void ReproducirSonido(int indice)
    {
        if (indice < 0 || indice >= sonidosAmbientales.Length) return;  // Índice fuera de rango

        sonidoActual = indice;
        fuenteAudio.clip = sonidosAmbientales[sonidoActual];
        fuenteAudio.Play();
    }

    // Ajustar el volumen de los sonidos ambientales
    public void AjustarVolumen(float volumen)
    {
        fuenteAudio.volume = volumen;
    }

    // Ajustar el tono de los sonidos ambientales
    public void AjustarTono(float tono)
    {
        fuenteAudio.pitch = tono;
    }

    public void OneShotClipSteeps()
    {
        int inx = Random.Range(0, 5);

        AjustarVolumen(0.5f);
        sonidoActual = inx;
        fuenteAudio.PlayOneShot(sonidosAmbientales[sonidoActual]);
    }
}
