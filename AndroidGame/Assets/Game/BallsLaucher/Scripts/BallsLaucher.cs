using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsLaucher : MonoBehaviour
{
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
    }
    private void Update()
    {
        if (readyToLauch)
        {
            StartCoroutine(Lauch());
        }
    }


    IEnumerator Lauch()
    {
        readyToLauch = false;
        transform.position = positions[Random.Range(0, positions.Length)].position;
        Vector2 dir = transform.position - target.position;
        GameObject Projectile = prefabs[Random.Range(0, prefabs.Length)];
        GameObject projectileGoing = Instantiate(Projectile, transform.position, transform.rotation);
        projectileGoing.GetComponent<Rigidbody2D>().velocity = -dir * velocity;
        yield return new WaitForSeconds(timeWait);
        readyToLauch = true;
    }

}
