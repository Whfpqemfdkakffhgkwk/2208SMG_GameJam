using UnityEngine;

public class Bike : MonoBehaviour
{
    float speed;
    
    void Start()
    {
        speed = Random.Range(1.0f, 1.5f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }
}
