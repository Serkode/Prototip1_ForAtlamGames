using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPosition;
    float time;
    public float limitTime;
    
    [SerializeField] Animator gunRecoil;
    [SerializeField] AudioSource gunFire;

    
    void Update()
    {
        time += Time.deltaTime;
        if(time >= limitTime)//Fire the Gun in every "limitTime" seconds.
        {
            FireTheGun();
        }
    }

    public void FireTheGun()
    {
        gunRecoil.Play("Recoil");//Play recoil animation in every Fire.
        gunFire.Play();//Play Gun Fire Sound in every Fire.
        Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
        time = 0;
    }
}
