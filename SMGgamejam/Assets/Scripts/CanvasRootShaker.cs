using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRootShaker : MonoBehaviour
{
    [SerializeField]
    RectTransform rt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition = new Vector2(Random.Range(-5, 5), Random.Range(-10, 10));
    }
}
