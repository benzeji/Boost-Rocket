using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private int screenNum;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is Frendly");
                break;
            case "Finish":
                Debug.Log("This thing is Finish");
                break;
            case "Fuel":
                Debug.Log("Your used FUel!");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("SandBox", LoadSceneMode.Additive);
    }
}
