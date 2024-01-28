using UnityEngine;
using UnityEngine.Audio;

public class VolumenControl : MonoBehaviour
{
    public static VolumenControl instancia;
    public AudioMixer mezclador;
    private float volumenMusica;
    private float volumenEfectos;
    private float volumenVoz;

    private void Awake()
    {
        // Implementación de Singleton
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            // Cargar las preferencias de volumen al iniciar
            volumenMusica = PlayerPrefs.GetFloat("volumenMusica", 0.75f);
            volumenEfectos = PlayerPrefs.GetFloat("volumenEfectos", 0.75f);
            volumenVoz = PlayerPrefs.GetFloat("volumenVoz", 0.75f);
            AplicarVolumen();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ControlVolumenMusica(float volumen)
    {
        volumenMusica = volumen;
        AplicarVolumen();
        // Guardar la preferencia de volumen
        PlayerPrefs.SetFloat("volumenMusica", volumen);
    }

    public void ControlVolumenEfectos(float volumen)
    {
        volumenEfectos = volumen;
        AplicarVolumen();
        // Guardar la preferencia de volumen
        PlayerPrefs.SetFloat("volumenEfectos", volumen);
    }

    public void ControlVolumenVoz(float volumen)
    {
        volumenVoz = volumen;
        AplicarVolumen();
        // Guardar la preferencia de volumen
        PlayerPrefs.SetFloat("volumenVoz", volumen);
    }

    private void AplicarVolumen()
    {
        mezclador.SetFloat("VolumenMusica", volumenMusica);
        mezclador.SetFloat("VolumenEfectos", volumenEfectos);
        mezclador.SetFloat("VolumenVoz", volumenVoz);
    }
}
