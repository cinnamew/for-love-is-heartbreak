using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ch3Images : MonoBehaviour , IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 force;
    private Vector3 mousePrevLocation;
    private Vector3 mouseCurrLocation;
    public GameObject objBoundaryTopRightCorner;
    public GameObject objBoundaryBottomLeftCorner;
    private Rigidbody2D rb;
    //public float topSpeed = 100;
    public Camera mainCam;
    private Vector2 screenBounds;

    private bool colliding = false;
    private bool dragging = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.2f, Screen.height*1.2f, 0));
        objBoundaryTopRightCorner.transform.position = screenBounds;

        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(0 - Screen.width*0.2f, 0 - Screen.height*0.2f, 0));
        objBoundaryBottomLeftCorner.transform.position = screenBounds;
       // mainCam = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, 5);
        //print(force + "; y: " + force.y);
        if(force.y > 0.0f) {
            //print("before : " + force.y);
            force.y = 0.99f*force.y;
            //print("after: " + force.y);
        }else if(force.y < 0.0f) force.y = 0.99f*force.y;
        if(force.x > 0.0f) force.x = 0.99f*force.x;
        else if(force.x < 0.0f) force.x = 0.99f*force.x;
        /*var pos = mainCam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);*/
    }

    void LateUpdate() {
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
        //transform.position = viewPos;
    }

    void FixedUpdate() {
        rb.velocity = new Vector3(force.x, force.y, 0);
        //print(force);
    }

    public void OnPointerUp(PointerEventData eventData) {
        //print("pointer up");
        if(!dragging) return;
        force = mouseCurrLocation - mousePrevLocation;
        //print("curr: " + mouseCurrLocation + "; prev: " + mousePrevLocation + "; force: " + force);
        mousePrevLocation = mouseCurrLocation;
        dragging = false;
        /*if(rb.velocity.magnitude > topSpeed) {
            force = rb.velocity.normalized * topSpeed;
        }*/
    }

    public void OnPointerDown(PointerEventData eventData) {
        //print("pointer down");
        mousePrevLocation = (Vector3)(eventData.delta);
        mousePrevLocation = rb.position;
        //position.x, eventData.position.y, 0
    }

    /*public void OnPointerClick(PointerEventData eventData) {
        print("clicked");
    }*/

    /*void OnMouseDrag() {
        print("mouse dragged");
        //transform.position = GetMousePos();
    }

    /*private Vector3 GetMousePos() {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }*/

    public void OnDrag(PointerEventData eventData) {
        //print("dragging");
        dragging = true;
        if(!colliding) this.transform.position += (Vector3)eventData.delta;
        mouseCurrLocation = (Vector3)eventData.delta;
        mouseCurrLocation = rb.position;
        colliding = false;
        //print(force);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //print(collision.gameObject.tag);
        if(collision.gameObject.tag == "border") {
            colliding = true;
            force.x = -force.x;
            force.y = -force.y;
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
