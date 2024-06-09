
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    BallsLaucher ballsLaucher;
    bool isRestart; 

    [Header("Tela Do Jogo")]
    [Space]


    public GameObject gameHUD;
    [SerializeField] TextMeshProUGUI HUD_txtLifes;
    [SerializeField] TextMeshProUGUI HUD_txtScore;
    [SerializeField] TextMeshProUGUI HUD_txtBestScore;
    [SerializeField] PlayerStts playerStts;
    [Space]


    [Header("Tela De Morte")]
    [Space]
    public GameObject dethSreen;
    [SerializeField] TextMeshProUGUI DS_txtScore;
    [SerializeField] TextMeshProUGUI DS_txtBestScore;
    [Space]


    [Header("Tela Do Menu")]
    [SerializeField] GameObject mainMenu;
    [Space]


    public GameObject menuScreen;
    [SerializeField] TextMeshProUGUI MS_txtScore;
    [Space]


    [Header("Tela De Configuracao")]
    [Space] 
    public GameObject configScreen;
    [Space]

    [Header("Funcoes")]
    
    [SerializeField] string gameSceaneName;
    public static UImanager Instance;

    [Header("Controle de animações")]
    [SerializeField]Animator GUIanimator;

    public void DathScreen()
    {
       
        ShowScreen(dethSreen);
        CloseScreen(gameHUD);
        DS_txtBestScore.text = playerStts.bestScore.ToString();
        DS_txtScore.text = playerStts.score.ToString();

        print(DS_txtBestScore);
        print(DS_txtScore);
    }
    private void Start()
    {
        if (isRestart) { mainMenu.SetActive(false); }
    }

    private void Update()
    {
     
        if (GameManager.Instance.playerIsDead)
        {
            DathScreen();
            
            GUIanimator.SetTrigger("deth_screen");
        }
        HUD_txtBestScore.text = playerStts.bestScore.ToString();
        HUD_txtLifes.text = playerStts.lifes.ToString();
        HUD_txtScore.text = playerStts.score.ToString();

   

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
        GUIanimator.SetTrigger("menu_screen");
        ShowScreen(menuScreen);
      
        Time.timeScale = 0;
       

    }
    //fecha o menu do jogo 
    public void btnCloseMenu()
    {
        CloseScreen(menuScreen); 
    }

    public void BtnStartGame()
    {


        GameManager.Instance.StartGame();
        CloseScreen(mainMenu);
        
    }
    //Recomeca o jogo 

    public void BtnRestartGame()
    {
        isRestart = true;
      
        gameHUD.SetActive(true);
        GameManager.Instance.playerIsDead = true;
        GameManager.Instance.RestartGame("SampleScene");
        Time.timeScale = 1;
        CloseScreen(mainMenu);
        
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
        ShowScreen(mainMenu);
        isRestart = false;
       // CloseScreen(menuScreen);
    }
    //abre a tela de configuracao do jogo 
    public void BtnOpenConfigScreen()
    {
        ShowScreen(configScreen);
        CloseScreen(menuScreen);
        CloseScreen(mainMenu);  

        GUIanimator.SetTrigger("config_screen");

    }
    //fecha a tela de configuracao 
    public void BtnCloseConfigScreen()
    {
        ShowScreen(menuScreen);
        CloseScreen(configScreen);
        GUIanimator.SetTrigger("menu_screen");

    }



}
