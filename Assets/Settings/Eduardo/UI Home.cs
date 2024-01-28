using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHome : MonoBehaviour
{
    [SerializeField] private GameObject FadeInPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        FadeInPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
