using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMoveOnCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        //print(collision.gameObject.tag);
        if(collision.gameObject.tag == "border") {
            //colliding = true;
            //force.x = -force.x;
            //force.y = -force.y;
            //rb.freezeRotation = true;
            //print("collided");
        }else {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
            //print("ignoring collision hopefully?");
            //rb.freezeRotation = false;
        }
        //print(force.y);
    }
}
