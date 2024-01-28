using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSonidoAgua : GestionEfectosSonido
{
    public AudioSource aguaLejosDerecho;
    public AudioSource aguaLejosIzquierdo;
    public AudioSource aguaCercaDerecho;
    public AudioSource aguaCercaIzquierdo;
    public AudioSource ahogandoseDerecho;
    public AudioSource ahogandoseIzquierdo;

    public List<bool> aguaLejosDerechoBools = new List<bool>();
    public List<bool> aguaLejosIzquierdoBools = new List<bool>();
    public List<bool> aguaCercaDerechoBools = new List<bool>();
    public List<bool> aguaCercaIzquierdoBools = new List<bool>();
    public List<bool> ahogandoseDerechoBools = new List<bool>();
    public List<bool> ahogandoseIzquierdoBools = new List<bool>();

    public static GestionSonidoAgua Instance;

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
    }

    private void RevisarEstadoSonido(AudioSource fuenteAudio, List<bool> listaBoolsFuenteAudio )
    {
        if (listaBoolsFuenteAudio == null)
        {
            fuenteAudio.Stop();
        }
    }
    
}
