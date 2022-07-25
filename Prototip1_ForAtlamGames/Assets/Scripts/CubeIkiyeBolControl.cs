using UnityEngine;

public class CubeIkiyeBolControl : MonoBehaviour
{
    public float CubeSpeed;
    GameObject gun;

    void Start()//This object to decrease the speed of the Gun.
    {
        gun = GameObject.FindGameObjectWithTag("gun");
        Destroy(gameObject, 7);
    }
    void Update()
    {
        transform.position -= transform.forward * CubeSpeed * Time.deltaTime;

        if (!gun.GetComponent<GunControl>().enabled)
        {
            Destroy(gameObject);
        }
    }
}
