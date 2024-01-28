using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isLivePlayer = true;

    private bool isPause = false;

    public GameObject pausePanel;
    public GameObject winPanel;

    private void Update()
    {
        if(isLivePlayer == false)
        {
            GameOver();
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);

            }
            else
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void Win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
}
