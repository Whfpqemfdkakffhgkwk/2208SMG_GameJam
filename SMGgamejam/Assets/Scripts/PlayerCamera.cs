using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float initialY;
    
    void Awake()
    {
        initialY = transform.position.y;
    }
    
    void LateUpdate()
    {
        var transform1 = transform;
        var p = transform1.position;
        p.y = initialY;
        transform1.position = p;
    }
}
