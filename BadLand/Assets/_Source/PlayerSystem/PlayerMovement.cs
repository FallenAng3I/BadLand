using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float liftForce = 5f; // Сила подъёма
        [SerializeField] private float speed = 5;
        private bool _isGround;
        
        private Rigidbody2D rb;
        [SerializeField] private LayerMask groundLayer;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, liftForce);
        }

        public void Move(float horizontalInput)
        {
            if (_isGround == false)
            {
                rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
            {
                _isGround = true;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
            {
                _isGround = false;
            }
        }
    }
}
