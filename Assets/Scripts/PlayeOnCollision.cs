using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeOnCollision : MonoBehaviour
{
    public GameObject Boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Instantiate(Boom,transform.position, Boom.transform.rotation);
        }
        
    }
}
