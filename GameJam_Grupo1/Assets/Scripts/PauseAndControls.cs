using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndControls : MonoBehaviour
{
    public GameObject canvasObj;
    private bool isPaused;
    public GameObject pauseButton;
    public GameObject playButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateGameState();            
        }
    }

    public void UpdateGameState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            canvasObj.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            canvasObj.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
