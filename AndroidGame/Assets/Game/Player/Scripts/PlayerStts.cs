using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStts : MonoBehaviour 
{ 
    public int lifes;
    public int score;
    public int bestScore;
    public int level;
    public int coins;

    private void Update()
    {
        bestScore = PlayerPrefs.GetInt("Best Score");
        if (score >= bestScore)
        {
            bestScore = 0 + score;
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Best Score", bestScore);
        PlayerPrefs.Save();

        if(lifes <= 0) {

           // Destroy(gameObject);
          
            GameManager.Instance.playerIsDead = true;

        }

       
    }




}
