using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public string gameSceaneName;
    public void BtnStartGame()
    {
        SceneManager.LoadScene(gameSceaneName);
    }
}
