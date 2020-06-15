using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
   public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ATGScene()
    {
        SceneManager.LoadScene("ATG");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GameQuit()
    {
        SceneManager.LoadScene("QuitScene");
    }
}
