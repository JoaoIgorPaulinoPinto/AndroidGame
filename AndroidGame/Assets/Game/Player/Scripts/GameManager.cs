
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool playerIsDead = false;
 
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
       //playerIsDead= true;
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
    public void StartGame()
    {
        playerIsDead = false;

    }
}
