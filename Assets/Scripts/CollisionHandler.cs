using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay;
    [SerializeField] private AudioClip finishClip;
    [SerializeField] private AudioClip crashClip;
    [SerializeField] private ParticleSystem finishParticle;
    [SerializeField] private ParticleSystem crashParticle;

    private AudioSource audioSource;
    private bool isTransitioning;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("This thing is Start");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        finishParticle.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishClip);
        GetComponent<MovementPlayer>().enabled = false;
        Invoke(nameof(LoadNextLevel), levelLoadDelay);
    }
    
    private void StartCrashSequence()
    {
        crashParticle.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashClip);
        GetComponent<MovementPlayer>().enabled = false;
        Invoke(nameof(ReloadLevel), levelLoadDelay);
    }
    
    private void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    
    private void ReloadLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}