using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadBritVictory()
    {
        SceneManager.LoadScene("BritVictory");
    }

    public void LoadGermVictory()
    {
        SceneManager.LoadScene("GermVictory");
    }

    public void LoadUnitSelect()
    {
        SceneManager.LoadScene("UnitSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
