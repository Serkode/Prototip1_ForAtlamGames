using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] Rigidbody rig;

    [SerializeField] float speed;

    public ParticleSystem littleExplosion, puffEffect;

    GunControl gun;
    void Start()
    {
        rig.AddForce(transform.forward * speed);
        Destroy(gameObject, 4);
        gun = GameObject.Find("Gun").GetComponent<GunControl>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("x2"))//This code to increase the speed of the Gun.
        {
            GameObject ikiyeBolCube = GameObject.FindGameObjectWithTag("ikiyebol");//"ikiye bol" means divide into two.
            gun.limitTime /= 2;
            Instantiate(puffEffect, transform.position, Quaternion.identity);
            Destroy(ikiyeBolCube);//Destroy the decreasing cube when bullet hit the increasing cube.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag.Equals("ikiyebol"))//This code to decrease the speed of the Gun. "ikiye bol" means divide into two.
        {
            GameObject x2Cube = GameObject.FindGameObjectWithTag("x2");
            gun.limitTime *= 2;
            Instantiate(puffEffect, transform.position, Quaternion.identity);
            Destroy(x2Cube);//Destroy the increasing cube when bullet hit the decreasing cube.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag.Equals("PA_drone"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag.Equals("PA_warrior"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        else if (collision.gameObject.tag.Equals("metalongreen") || collision.gameObject.tag.Equals("metalonpurple") || collision.gameObject.tag.Equals("metalonred"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag.Equals("slime") || collision.gameObject.tag.Equals("turtle"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag.Equals("spiderblack") || collision.gameObject.tag.Equals("spiderbrown") || collision.gameObject.tag.Equals("spidergreen"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag.Equals("spikeballbig") || collision.gameObject.tag.Equals("spikeballsmall"))
        {
            Instantiate(littleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

