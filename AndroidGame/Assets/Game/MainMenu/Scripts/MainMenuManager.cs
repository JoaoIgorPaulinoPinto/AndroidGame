using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Tela De Configuracao")]
    [Space]
    public GameObject configScreen;
    public GameObject inicialScreen;
    [Space]

    [Header("Controle de animações")]
    [SerializeField] Animator GUIanimator;

    public string gameSceneName;


  

    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    public void CloseScreen(GameObject screenToClose)
    {
        screenToClose.SetActive(false);
    }

    public void BtnOpenConfigScreen()
    {
        CloseScreen(inicialScreen);

        ShowScreen(configScreen);
        GUIanimator.ResetTrigger("config_screen");
        GUIanimator.Play("open");

    }


    //fecha a tela de configuracao  
    public void BtnCloseConfigScreen()
    {
        ShowScreen(inicialScreen);
        CloseScreen(configScreen);
    }
}
