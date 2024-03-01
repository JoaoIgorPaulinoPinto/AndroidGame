using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtLifes;
    [SerializeField] TextMeshProUGUI txtPoints;


    public int lifes;
    public int points;
    public int level;
    public int coins;

    private void Update()
    {
        txtLifes.text = lifes.ToString();
        txtPoints.text = points.ToString();

        if(lifes <= 0)
        {
            Destroy(gameObject);
        }
    }
}
