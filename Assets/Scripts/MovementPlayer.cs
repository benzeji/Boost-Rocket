using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float mainThrust = 5f;
    [SerializeField] private float rotationThrust = 1f;
    [SerializeField] private float incrementPitch = 0.1f;
    private float targetPitch;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
       audioSource.Play();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    // Traction treatment

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
            targetPitch = 3f;
        }

        else
        {
            targetPitch = 0f;
        }
        
        audioSource.pitch = Mathf.Lerp(audioSource.pitch, targetPitch, incrementPitch * Time.deltaTime);
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
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
    }
}