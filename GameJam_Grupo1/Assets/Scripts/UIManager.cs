using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject canvasObj;
    public GameObject pauseButton;
    public GameObject playButton;
    public TextMeshProUGUI woodPoints;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        //Actualiza el texto para llevar conteo de cantidad de recursos
        woodPoints.text = "Madera: " + playerController.wood.ToString();

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
