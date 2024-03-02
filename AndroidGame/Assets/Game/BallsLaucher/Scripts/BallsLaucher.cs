using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallsLaucher : MonoBehaviour
{
    PlayerStts playerStts;

    public float multiplyer;
    public float multiplyerTime;


    Transform target;

    public GameObject[] prefabs;
    public float timeWait;
    public float velocity;
 
    public Transform[] positions;

    public bool readyToLauch;

    public int wave;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerStts = target.GetComponent<PlayerStts>();
    }
    private void Update()
    {
        if (playerStts.score > (multiplyerTime * 2) && multiplyer < 1)
        {
            multiplyer += 0.1f;
            multiplyerTime = playerStts.score; 
        }
        if (readyToLauch)
        {
            StartCoroutine(Lauch());
        }
        
    }


    IEnumerator Lauch()
    {
        readyToLauch = false;
        transform.position = positions[Random.Range(0, positions.Length)].position;

        GameObject Projectile = prefabs[Random.Range(0, prefabs.Length)];

        GameObject projectileGoing = Instantiate(Projectile, transform.position, transform.rotation);

        while (!readyToLauch)
        {
            MoveProjectile(projectileGoing);
            yield return null; // Aguardar até o próximo quadro
            break;
        }

        yield return new WaitForSeconds(timeWait);
        readyToLauch = true;
    }

    void MoveProjectile(GameObject projectileGoing)
    {
        Vector2 dir = (Vector2)target.position - (Vector2)projectileGoing.transform.position;
        projectileGoing.GetComponent<Rigidbody2D>().velocity = dir.normalized * (velocity + multiplyer);
    }
}
