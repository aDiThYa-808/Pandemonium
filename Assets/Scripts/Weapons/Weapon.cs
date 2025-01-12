using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Weapon : MonoBehaviour
{
    [Header("Bullet info")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 100f;
    public float bulletLifeTime = 3f;

    [Header("Gun info")]
    public GameObject GunHolder;
    public int AmmoCount;
    public float ReloadTime;
    public bool isReloading;

    [Header("Muzzle flash")]
    public GameObject MuzzleFlashPrefab;
    public Transform FlashPoint;
    public float FlashLifeTime;
    
    [Header("Gun Sounds")]
    public AudioClip FireClip;
    public AudioClip ReloadClip;

    [Header("Ammo display")]
    public TextMeshProUGUI AmmoText;



    private AudioSource audiosrc;
    private Animator anim;

    private void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
        anim = GunHolder.GetComponent<Animator>();
        AmmoCount = 25;
        isReloading = false;
        ReloadTime = 2.2f;
        FlashLifeTime = 0.2f;
        AmmoText.text = AmmoCount.ToString();
    }

    


    public void FireGun() 
    {
        if(AmmoCount> 0 && !isReloading)
        {
                audiosrc.clip = FireClip;
                audiosrc.Play();
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

                GameObject flash = Instantiate(MuzzleFlashPrefab,FlashPoint);
                Destroy(flash,0.2f);

                AmmoCount--;
                AmmoText.text = AmmoCount.ToString();

                StartCoroutine(DestroyBullet(bullet, bulletLifeTime));

                StartCoroutine(ReloadGun());
        }
       
        


        
    }


    IEnumerator ReloadGun() 
    {
       
        anim.SetBool("reload", true);
        isReloading = true;
        audiosrc.PlayOneShot(ReloadClip);
        yield return new WaitForSeconds(ReloadTime);
        isReloading = false;
        anim.SetBool("reload",false);
    }

    IEnumerator DestroyBullet(GameObject bullet , float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
