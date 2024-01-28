using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound; // Sonido al pasar el puntero
    public AudioClip clickSound; // Sonido al hacer clic

    public AudioSource source;

    // Cuando el puntero pasa sobre el bot�n
    public void OnPointerEnter(PointerEventData eventData)
    {
        source.clip = hoverSound;
        source.Play();
    }

    // Cuando se hace clic en el bot�n
    public void OnPointerClick(PointerEventData eventData)
    {
        source.clip = clickSound;
        source.Play();
    }
}