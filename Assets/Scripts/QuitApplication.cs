using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    private void Start()
    {
        ApplicationMenu();
    }

    private void ApplicationMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}