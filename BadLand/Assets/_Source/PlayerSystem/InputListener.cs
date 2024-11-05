using UnityEngine;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private PlayerMovement player;
        
        private void Update()
        {
            ReadJump();
            ReadMovement();
        }

        private void ReadJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.Jump();
            }
        }
        
        private void ReadMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            player.Move(horizontalInput);
        }
    }
}
