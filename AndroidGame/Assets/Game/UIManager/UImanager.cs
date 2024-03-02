using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    

    [SerializeField] string mainMenuSceaneName;
    [SerializeField] string gameSceaneName;

    [SerializeField] PlayerStts playerStts;

    [SerializeField] TextMeshProUGUI HUD_txtLifes;
    [SerializeField] TextMeshProUGUI HUD_txtScore;
    [SerializeField] TextMeshProUGUI HUD_txtBestScore;

    [SerializeField] TextMeshProUGUI DS_txtScore;
    [SerializeField] TextMeshProUGUI DS_txtBestScore;

    [SerializeField] TextMeshProUGUI MS_txtScore;

    public GameObject gameHUD;
    public GameObject menuScreen;
    public GameObject dethSreen;
    public GameObject configScreen;

    public static UImanager Instance;

    public void DathScreen()
    {
       
        ShowScreen(dethSreen);
        CloseScreen(gameHUD);

        

    }


    private void Update()
    {

        if (GameManager.Instance.playerIsDead)
        {
            DathScreen();
        }
        HUD_txtBestScore.text = playerStts.Bestscore.ToString();
        HUD_txtLifes.text = playerStts.lifes.ToString();
        HUD_txtScore.text = playerStts.score.ToString();

        DS_txtBestScore.text = playerStts.Bestscore.ToString();
        DS_txtScore.text = playerStts.score.ToString();

        MS_txtScore.text = playerStts.score.ToString();
    }
    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
        
    }
    public void CloseScreen(GameObject screenToClose)
    {
        screenToClose.SetActive(false);
    }

    //abre o menu com as opcoes do jogador, config, sair, etc 
    public void btnOpenMenu()
    {
        ShowScreen(menuScreen);
        Time.timeScale = 0;
    }
    //fecha o menu do jogo 
    public void btnCloseMenu()
    {
        CloseScreen(menuScreen);
    }
    //Recomeca o jogo 

    public void BtnRestartGame()
    {
        GameManager.Instance.RestartGame(gameSceaneName);
        gameHUD.SetActive(true);
        Time.timeScale = 1;
        GameManager.Instance.playerIsDead = true;
    }
    //volta a jogar de onde parou 
   
    public void BtnResume()
    {
        CloseScreen(menuScreen);
        Time.timeScale = 1;
    }
    //volta para o menu principal

    public void BtnBackToMainMenu()
    {
        GameManager.Instance.LoadSceane(mainMenuSceaneName);
    }
    //abre a tela de configuracao do jogo 
    public void BtnOpenConfigScreen()
    {
        ShowScreen(configScreen);
        CloseScreen(menuScreen);
    }
    //fecha a tela de configuracao 
    public void BtnCloseConfigScreen()
    {
        ShowScreen(menuScreen);
        CloseScreen(configScreen);

    }


    
}
