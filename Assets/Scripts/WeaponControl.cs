using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public int AmmoCapacity = 7;
    public int AvailableAmmo;
    private bool CanShoot = true;
    private float ShootCD = 0.5f, ReloadCD = 3f;

    public GameObject Bullet;
    public GameObject Player;
    public GameObject Muzzle;
    public GameObject Flash;
    public SpriteRenderer Sprite;

    



    private AudioSource AudioSource;
    public AudioClip GunShoot;

    private Vector3 GunOffset = new Vector3(-0.045f, 0, 0);

    Vector2 mousePos;
    
    public Camera cam;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AvailableAmmo = AmmoCapacity;
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate to mouse position
        transform.position = Player.transform.position + GunOffset;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;

        // Shoot
        if (Input.GetMouseButtonDown(0) && AvailableAmmo>0 && CanShoot)
        {
            CanShoot = false;
            StartCoroutine(ShootCooldown());
            AvailableAmmo--;
            AudioSource.PlayOneShot(GunShoot, 1);
            Shoot();
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            CanShoot = false;
            StartCoroutine(ReloadCooldown());
            AvailableAmmo = AmmoCapacity;
        }

        // Flip
        Vector3 CharactereScale = transform.localScale;
        if (Player.transform.localScale.x <0)
        {
            CharactereScale.x = -0.05f;
            Sprite.flipY = false;
        }
        if (Player.transform.localScale.x > 0)
        {
            CharactereScale.x = 0.05f;
            Sprite.flipY = true;
        }
        transform.localScale = CharactereScale;

        

    }
    public void Shoot()
    {
        Instantiate(Bullet, Muzzle.transform.position, Muzzle.transform.rotation);
        Instantiate(Flash, Muzzle.transform.position, Muzzle.transform.rotation);
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(ShootCD);
        CanShoot = true;
    }

    IEnumerator ReloadCooldown()
    {
        yield return new WaitForSeconds(ReloadCD);
        CanShoot = true;
    }

}
