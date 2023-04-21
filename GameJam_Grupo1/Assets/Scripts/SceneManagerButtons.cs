using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerButtons : MonoBehaviour
{

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(2);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
