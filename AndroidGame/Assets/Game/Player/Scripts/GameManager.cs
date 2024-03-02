using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool playerIsDead = false;
    int playerScore;
    int playerBestScore;
    [SerializeField] PlayerStts playerStts;

    public static GameManager Instance;
    
    private void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Mais de uma instância de UIManager encontrada na cena.");
            Destroy(gameObject);
        }
       
    }

    public void LoadSceane(string sceaneName)
    {
        SceneManager.LoadScene(sceaneName);
    }
    public  void RestartGame(string gameSceaneName)
    {
        SceneManager.LoadScene(gameSceaneName);
        playerIsDead = false;
    }
    public void PlayerDeth()
    {
        Time.timeScale = 0;
        playerIsDead = true;
        
    }
}
