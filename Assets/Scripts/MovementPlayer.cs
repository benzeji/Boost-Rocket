using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float mainThrust = 5f;
    [SerializeField] private float rotationThrust = 1f;

    private void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
        rigidBody.freezeRotation = false; // unfreezing rotation so the physics system can take over 
    }
}