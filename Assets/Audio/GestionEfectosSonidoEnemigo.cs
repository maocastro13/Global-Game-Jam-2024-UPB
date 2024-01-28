using System.Collections;
using UnityEngine;

public class GestionEfectosSonidoEnemigo : GestionEfectosSonido
{
    [SerializeField]
    public BancoDeSonidos[] bancosDeSonidos;

    public AudioSource cerca0;
    public AudioSource cerca1;
    public AudioSource lejos0;
    public AudioSource lejos1;

    void Start()
    {
        StartCoroutine(ReproducirSonidos());
    }

    IEnumerator ReproducirSonidos()
    {
        while (true)
        {
            // Reproducir el banco 0 en cerca0
            ReproducirSonido(cerca0, 0);
            ReproducirSonido(cerca1, 1);

            // Esperar la duración del clip antes de reproducir el siguiente
            yield return new WaitForSecondsRealtime(cerca0.clip.length / 5);
            yield return new WaitForSecondsRealtime(cerca1.clip.length / 5);

            // Reproducir el banco 2 en lejos0
            ReproducirSonido(lejos0, 2);
            ReproducirSonido(lejos1, 3);

            yield return new WaitForSecondsRealtime(lejos0.clip.length / 5);
            yield return new WaitForSecondsRealtime(lejos1.clip.length / 5);
        }
    }

    void ReproducirSonido(AudioSource fuenteAudio, int indiceBanco)
    {
        if (indiceBanco < bancosDeSonidos.Length)
        {
            int indiceSonido = Random.Range(0, bancosDeSonidos[indiceBanco].sonidos.Length);
            fuenteAudio.clip = bancosDeSonidos[indiceBanco].sonidos[indiceSonido];
            fuenteAudio.Play();
        }
    }
}

