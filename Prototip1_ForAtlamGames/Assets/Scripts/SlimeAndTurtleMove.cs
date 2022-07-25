using UnityEngine;

public class SlimeAndTurtleMove : MonoBehaviour
{
    public float moveSpeed;

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
        if(transform.position.z <= 1 && !enemyLine)
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
            Instantiate(flameExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag.Equals("Player"))//For doon't collide with the Gun.
        {
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    private void OnDestroy()
    {
        gameManage.enemyDestroyed++;
    }
}
