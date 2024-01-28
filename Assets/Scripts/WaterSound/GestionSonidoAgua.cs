using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSonidoAgua : MonoBehaviour
{
    public AudioSource aguaLejosDerecho;

    public AudioSource aguaCercaDerecho;
 
    public AudioSource ahogandoseDerecho;


    public List<bool> aguaLejosDerechoBools = new List<bool>();
    
    public List<bool> aguaCercaDerechoBools = new List<bool>();

    public List<bool> ahogandoseDerechoBools = new List<bool>();
 

    public static GestionSonidoAgua Instance;

    private void Awake()
    {
      Instance = this;
    }

    public void EntraZonaAgua(AudioSource fuenteAudio, List<bool> listaBoolsFuenteAudio)
    {
        if(listaBoolsFuenteAudio == null)
        {
            listaBoolsFuenteAudio.Add(true);
            fuenteAudio.Play();
        }
        else
        {
            listaBoolsFuenteAudio.Add(true);
        }
    }

    public void SalirZonaAgua(AudioSource fuenteAudio, List<bool> listaBoolsFuenteAudio)
    {
        listaBoolsFuenteAudio.Remove(true);
        RevisarEstadoSonido(fuenteAudio, listaBoolsFuenteAudio);
        SolucionarSuperposicion();
    }

    private void RevisarEstadoSonido(AudioSource fuenteAudio, List<bool> listaBoolsFuenteAudio )
    {
        if (listaBoolsFuenteAudio == null)
        {
            fuenteAudio.Stop();

            if (fuenteAudio == ahogandoseDerecho || fuenteAudio == aguaCercaDerecho)
            {
                SolucionarSuperposicion();
            }
        }
    }

    private void SolucionarSuperposicion()
    {
        if(ahogandoseDerecho.isPlaying && aguaCercaDerecho.isPlaying)
        {
            aguaCercaDerecho.Stop();
        }

       if(ahogandoseDerecho.isPlaying && aguaLejosDerecho.isPlaying)
        {
            aguaLejosDerecho.Stop();
        }

       else if (aguaCercaDerecho.isPlaying && aguaLejosDerecho.isPlaying)
        {
                aguaLejosDerecho.Stop();
        }
    }

    private void ReversarSoluciónSuperposición()
    {
        if(!ahogandoseDerecho.isPlaying && !aguaCercaDerecho.isPlaying && aguaCercaDerechoBools != null )
        {
            aguaCercaDerecho.Play();
        }

        else if(!ahogandoseDerecho.isPlaying && !aguaCercaDerecho.isPlaying && !aguaLejosDerecho.isPlaying && aguaLejosDerechoBools != null)
        {
            aguaLejosDerecho.Play();
        }
    }
    
}
