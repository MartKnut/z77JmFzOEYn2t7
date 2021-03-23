using System;
using SoundScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovementScript : MonoBehaviour
    {
        
        
        public Animator anim;
        // We want to get this gameObject's Rigidbody2D, let's call it "rb"
        private Rigidbody2D rb;
        public Rigidbody2D pointer;

        // The speed we want our gameObject to move. (The Player)
        public float moveSpeed;

        // We need the camera to know where to shoot
        public Camera cam;

        // Variable for a 2D vector
        private Vector2 movement;
        private Vector2 mousePosition;

        // Start is called before the first frame update
        void Start()
        {
            // rb is equal to this gameObject's component Rigidbody2D
            rb = gameObject.GetComponent<Rigidbody2D>();
            // Writing this defeats the purpose of having rb public, and is more effective for the engine.
        }
        
        // Update is called once per frame
        void Update()
        {
            FixedUpdate();
            Movement();
            
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        // private void MousePos() {}
        private void Movement()
        {
            // FindObjectOfType<AudioManager>().Play("Walk");


            // Gets the Horizontal X value, and Vertical Y value. WS,AD or Arrow Keys in this case.
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            // We want to give our rigidbody rb a velocity of (+-1 * Movespeed). GetAxisRaw gives us a value of either 1 or 0.
            // This gives the player snappy and satisfying controlling, and not floaty like GetAxis

            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);

        }

        private void FixedUpdate()
        {
            rb.velocity = movement.normalized * moveSpeed;

            MouseControl();
        }

        private void MouseControl()
        {
            
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
            
            // I need a Vector2 value to get the angle from mouse to rigidbody.
            Vector2 lookDirection = mousePosition - rb.position;
            
            // I want the pointer to follow the player
            pointer.position = rb.position;
            
            // get the angle of Y and X from the previous Vector 2. Use it to tell the pointer where to rotate towards.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            pointer.rotation = angle;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointer.position, mousePosition);
            Gizmos.DrawSphere(mousePosition, .3f);
        }
    }
}
