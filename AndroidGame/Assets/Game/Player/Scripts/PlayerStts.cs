using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStts : MonoBehaviour 
{ 
    public int lifes;
    public int score;
    public int Bestscore;
    public int level;
    public int coins;

    private void Update()
    {
        Bestscore = PlayerPrefs.GetInt("Best Score");
        if (score >= Bestscore)
        {
            Bestscore = 0 + score;
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Best Score", Bestscore);
        PlayerPrefs.Save();

        if(lifes <= 0) {

            Destroy(gameObject);
          
            GameManager.Instance.playerIsDead = true;

        }
    }
}
