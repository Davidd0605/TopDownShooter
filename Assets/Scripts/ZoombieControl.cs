using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoombieControl : MonoBehaviour
{
    public float speed;
    private GameObject Player;
    private Rigidbody2D Rigidbody;
    private SpriteRenderer Sprite;

    public PlayerControl PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerControl>();
        Sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (Player.transform.position - transform.position).normalized;
        Rigidbody.AddForce(LookDirection * speed , ForceMode2D.Impulse );

        if (transform.position.x < Player.transform.position.x)
        {
            Sprite.flipX = true;
        }
        else
        {
            Sprite.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            Destroy(Player);
            PlayerScript.GameOver = true;
            Debug.Log("Game Over! " + PlayerScript.GameOver);
            
        }
    }
}
