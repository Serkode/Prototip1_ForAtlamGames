using UnityEngine;

public class PA_WarriorMove : MonoBehaviour
{
    public float moveSpeed;
    short countWarrior = 0;

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

        if (transform.position.z <= 1 && !enemyLine)
        {
            enemyLineSound.Play();
            gameManage.enemyFailNumber++;
            enemyLine = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            countWarrior++;
            if (countWarrior >= 4)
            {

                countWarrior = 0;
                Instantiate(flameExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            Debug.Log(countWarrior);
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
