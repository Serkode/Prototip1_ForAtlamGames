using UnityEngine;

public class CubeX2Control : MonoBehaviour
{
    public float CubeSpeed;
    GameObject gun;

    void Start()//This object to increase the speed of the Gun.
    {
        gun = GameObject.FindGameObjectWithTag("gun");
        Destroy(gameObject, 7);
    }


    void Update()
    {
        transform.position -= transform.forward * CubeSpeed *Time.deltaTime;

        if(!gun.GetComponent<GunControl>().enabled)
        {
            Destroy(gameObject);
        }
    }
}
