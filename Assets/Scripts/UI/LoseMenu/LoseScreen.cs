using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        GameManager.Instance.ResetAll();
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        GameManager.Instance.ResetAll();
        SceneManager.LoadScene("Nando");
    }
}
