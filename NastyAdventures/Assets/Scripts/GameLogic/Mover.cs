using UnityEngine;

public class Mover
{
  

    public Vector3 GetVectorInInput(CharacterController executor, float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = executor.transform.right * x + executor.transform.forward * z;
        return move;
    }

    public Vector3 GetVectorToTarget(CharacterController executor, Player target, float speedToRotate)
    {
        Vector3 trueDirection = target.transform.position;
        trueDirection.y = executor.transform.position.y;

        Vector3 targetDirection = trueDirection - executor.transform.position;
        float singleStep = speedToRotate * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(executor.transform.forward, targetDirection, singleStep, 0.0f);
        return newDirection;
    }

    public void MoveToVector(CharacterController executor, Vector3 move, float speed)
    {
        executor.Move(move * speed * Time.deltaTime);
    }

    public void RotateToVector(CharacterController executor, Vector3 vectorToTarget)
    {
        executor.transform.localRotation = Quaternion.LookRotation(vectorToTarget);
    }

    
    public Vector3 Jumping(float jumpHeight, Vector3 velocity, bool isGrounded, float gravity)
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        return velocity;
    }

    public float Boosting(float mainSpeed, float maxSpeed)
    {
        if (Input.GetKey("left shift"))
        {
            return maxSpeed;
        }
        else
        {
            return mainSpeed;
        }
    }

    public void Squatting(CharacterController executor)
    {
       
        if (Input.GetKey("c"))
        {
            executor.height = 1f;
        }
        else
        {
            executor.height = 2f;
        }
    }
}