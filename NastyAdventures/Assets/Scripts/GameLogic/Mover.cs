using UnityEngine;

public class Mover
{
    private Vector3 _velosity;

    public Vector3 GetVectorInInput(CharacterController executor, float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = executor.transform.right * x + executor.transform.forward * z;
        return move;
    }

    public Vector3 GetVectorToTarget(CharacterController executor, Player target, float _speedToRotate)
    {
        Vector3 trueDirection = target.transform.position;
        trueDirection.y = executor.transform.position.y;

        Vector3 targetDirection = trueDirection - executor.transform.position;
        float singleStep = _speedToRotate * Time.deltaTime;
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

    public bool GroundedChek(Transform groundCheck, LayerMask groundMask, float groundDistance)
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    public void Gravity(CharacterController executor, bool isGrounded, float massExecutor, float gravity)
    {
        if (isGrounded && _velosity.y < 0)
        {
            _velosity.y = -2f;
        }

        _velosity.y += massExecutor * gravity * Time.deltaTime;
        executor.Move(_velosity * Time.deltaTime);
    }
    public void Jumping(float jumpHeight, bool isGrounded, float gravity)
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velosity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
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