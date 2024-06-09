using System.Collections;

using UnityEngine;


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
        readyToLauch = true;
    }
    private void Update()
    {

            if (playerStts.score > multiplyerTime)
            {
                multiplyer += 0.05f;
                multiplyerTime = playerStts.score;
                timeWait -= 0.05f;
            }
            if (readyToLauch)
            {
                StartCoroutine(Lauch());
            }

    }


    IEnumerator Lauch()
    {
       

     
            readyToLauch = false;
            GameObject Projectile;
            GameObject projectileGoing;

            transform.position = positions[Random.Range(0, positions.Length)].position;
            Projectile = prefabs[Random.Range(0, prefabs.Length)];

            projectileGoing = Instantiate(Projectile, transform.position, transform.rotation);

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
