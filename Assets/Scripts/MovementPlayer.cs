using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float mainThrust = 100f;
    [SerializeField] private float rotationThrust = 1f;
    [SerializeField] private AudioClip mainEngine;
    [SerializeField] private ParticleSystem mainEngineParticle;
     
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    
    private void StartThrusting()
    {
        rigidBody.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }
    
    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }
    
    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
    }
    
    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
    }
}