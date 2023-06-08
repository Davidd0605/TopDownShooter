using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MovementSpeed = 20f;
    public Rigidbody2D rb;

    Vector2 movement;
    public GameObject Bullet;
    public GameObject Weapon;
    private SpriteRenderer Sprite;
    private bool IsOut;

    public bool GameOver;


    
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
       IsOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Flip 
        Vector3 CharactereScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            CharactereScale.x = 3;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            CharactereScale.x = -3;
        }
        transform.localScale = CharactereScale;

        // Weapon in and out

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (IsOut)
            { Weapon.SetActive(false); IsOut = false;}
            else
            { Weapon.SetActive(true); IsOut = true; }
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.deltaTime);
    }
    


}
