using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip[] hoverSounds; // Sonido al pasar el puntero
    public AudioClip clickSound; // Sonido al hacer clic

    public AudioSource source;

    // Cuando el puntero pasa sobre el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        int indiceSonido = Random.Range(0, 3);
        source.PlayOneShot(source.clip = hoverSounds[indiceSonido]);
    }

    // Cuando se hace clic en el botón
    public void OnPointerClick(PointerEventData eventData)
    {
        source.clip = clickSound;
        source.PlayOneShot(source.clip = clickSound);
    }
}