using UnityEngine;

public class PA_DroneMove : MonoBehaviour
{
    public GameObject FanRight, FanLeft;
    public float fanSpeed;
    public float moveSpeed;
    short count = 0;

    public ParticleSystem flameExplosion;

    GameControl gameManage;
    public bool enemyLine = false;

    public AudioSource enemyLineSound;

    void Start()
    {
        gameManage = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControl>();
    }


    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        FanRight.transform.Rotate(0, 10f * fanSpeed * Time.deltaTime, 0);//Rotating Drone's Fans
        FanLeft.transform.Rotate(0, -10f * fanSpeed * Time.deltaTime, 0);//Rotating Drone's Fans

        if (transform.position.z <= 1 && !enemyLine)
        {
            enemyLineSound.Play();
            gameManage.enemyFailNumber++;
            enemyLine = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("bullet"))
        {
            count++;
            if (count>=4)
            {
                count = 0;
                Instantiate(flameExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;//For doon't collide with the Gun.
        }
    }

    private void OnDestroy()
    {
        gameManage.enemyDestroyed++;
    }
}
