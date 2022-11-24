using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE");
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed Left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed Right");
        }
    }
}
