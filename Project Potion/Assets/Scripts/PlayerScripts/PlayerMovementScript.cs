using SoundScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovementScript : MonoBehaviour
    {
        private Animator anim;
            // We want to get this gameObject's Rigidbody2D, let's call it "rb"
        private Rigidbody2D rb;

        // The speed we want our gameObject to move. (The Player)
        public float moveSpeed;
        
        
        // Start is called before the first frame update
        void Start()
        {
            // rb is equal to this gameObject's component Rigidbody2D
            rb = gameObject.GetComponent<Rigidbody2D>();
            // Writing this defeats the purpose of having rb public, and is more effective for the engine.

            anim = gameObject.GetComponent<Animator>();
        }
        
        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            FindObjectOfType<AudioManager>().Play("Walk");
            
            
            // Gets the Horizontal X value, and Vertical Y value. WS,AD or Arrow Keys in this case.
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            // We want to give our rigidbody rb a velocity of (+-1 * Movespeed). GetAxisRaw gives us a value of either 1 or 0.
            // This gives the player snappy and satisfying controlling, and not floaty like GetAxis
            rb.velocity = new Vector2(x, y).normalized * moveSpeed;
            
        }

        private void AnimValue()
        {
            
        }
    }
}
