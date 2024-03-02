using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string gameSceaneName;
    public void BtnStartGame()
    {
        SceneManager.LoadScene(gameSceaneName);
    }
}
