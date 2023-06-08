using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffBounds : MonoBehaviour
{
    private float upbound = 6;
    private float lateralbound = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< -1* upbound || transform.position.y> upbound || transform.position.x> lateralbound || transform.position.x < -1* lateralbound)
        {
            if (CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
        
    }
}
