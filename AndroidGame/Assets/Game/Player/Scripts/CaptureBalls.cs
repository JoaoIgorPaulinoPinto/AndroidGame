using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaptureBalls : MonoBehaviour
{
    [SerializeField]PlayerStts playerStts;
    [SerializeField]string ballColorTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == ballColorTag)
        {
            playerStts.points++;
            Destroy(collision.gameObject);
        }
        else
        {
            playerStts.lifes--;
            Debug.Log("tomou dano");
            Destroy(collision.gameObject);
        }
    }
    
}
