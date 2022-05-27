using UnityEngine;




public class Gravity 
{
    

    public bool GroundedCheck(Transform groundCheck, LayerMask groundMask, float groundDistance)
    {
       
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    public Vector3 Attract(CharacterController executor, Vector3 velocity, bool isGrounded, float massExecutor)
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += massExecutor * -9.8f * Time.deltaTime;
        executor.Move(velocity * Time.deltaTime);
        return velocity;
      
    }
}
