using UnityEngine;

public class Oscillator : MonoBehaviour
{

    private Vector3 startingPosition;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0,1)] private float movementFactor;
    [SerializeField] private float period;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        MovementObstacle();
    }

    private void MovementObstacle()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        
        var cycles = Time.time / period; // continually growing over time
        const float tau = Mathf.PI * 2; // constant value of 6.283 
        var rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1
        movementFactor = (rawSinWave + 1f) / 2F; // recalculated to go from 0 to 1 so its cleaner
        var offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
