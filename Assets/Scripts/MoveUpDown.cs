using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float amplitude = 2.0f; 
    public float period = 2.0f;

    private Vector2 startDirection;
    private Vector2 startPosition; 

    void Start()
    {
        startPosition = transform.position;
        startDirection.x = 0;

        while (true)
        {
            print(Random.Range(0, 1));
        }
        
    }

    void Update()
    {
        float theta = Time.timeSinceLevelLoad / period; 
        float distance = amplitude * Mathf.Sin(theta); 

        transform.position = startPosition + startDirection * distance;
    }
}
