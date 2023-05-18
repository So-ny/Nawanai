using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void GoToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
