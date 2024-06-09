using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaptureBalls : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip pointSound;


    [SerializeField] PlayerStts playerStts;
    [SerializeField] string ballColorTag;

    [SerializeField] ParticleSystem particlePoint;
    [SerializeField] ParticleSystem particleHited;


    [SerializeField] Animator efectAnimtor;
    [SerializeField] Animator playerAnimator;


    ParticleSystem particleInstantiated;



    private void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == ballColorTag)
        {
            audioSource.clip = pointSound;
            audioSource.Play();

            playerAnimator.SetTrigger("hit");

            Vector2 direcao = collision.contacts[0].point - (Vector2)transform.position;
            Quaternion rotacaoParticula;
            if (Mathf.Abs(direcao.x) > Mathf.Abs(direcao.y))
            {
                if (direcao.x > 0)
                {
                    // Vindo da direita
                    rotacaoParticula = Quaternion.Euler(180, -90f, 90);
                }
                else
                {
                    // Vindo da esquerda
                    rotacaoParticula = Quaternion.Euler(0f, -90, 90);
                }
            }
            else
            {
                if (direcao.y > 0)
                {
                    // Vindo de cima
                    rotacaoParticula = Quaternion.Euler(-90, -90, 90);
                }
                else
                {
                    // Vindo de baixo
                    rotacaoParticula = Quaternion.Euler(90, -90, 90);
                }
            }

            particleInstantiated = Instantiate(particlePoint, collision.transform.position, rotacaoParticula);
            playerStts.score++;

            Destroy(collision.gameObject);
            Destroy(particleInstantiated.gameObject, 2f);
        }
        else
        {
            audioSource.clip = hitSound;
            audioSource.Play();

            Vector2 direcao = collision.contacts[0].point - (Vector2)transform.position;
            Quaternion rotacaoParticula;
            if (Mathf.Abs(direcao.x) > Mathf.Abs(direcao.y))
            {
                if (direcao.x > 0)
                {
                    // Vindo da direita
                    rotacaoParticula = Quaternion.Euler(180, -90f, 90);
                }
                else
                {
                    // Vindo da esquerda
                    rotacaoParticula = Quaternion.Euler(0f, -90, 90);
                }
            }
            else
            {
                if (direcao.y > 0)
                {
                    // Vindo de cima
                    rotacaoParticula = Quaternion.Euler(-90, -90, 90);
                }
                else
                {
                    // Vindo de baixo
                    rotacaoParticula = Quaternion.Euler(90, -90, 90);
                }
            }

            particleInstantiated = Instantiate(particleHited, collision.transform.position, rotacaoParticula);
            playerStts.lifes--;
            playerAnimator.SetTrigger("hit");
            efectAnimtor.SetTrigger("Player_hited");

            Destroy(particleInstantiated.gameObject, 2f);
            Destroy(collision.gameObject);

        }
    }
    void DestroyParticle()
    {
        if(particleInstantiated != null)
        {
            Destroy(particleInstantiated.gameObject, 2f);
        }
    }   

}
