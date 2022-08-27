using UnityEngine;

public class Cloud : MonoBehaviour
{
    RectTransform rt;

    public float speed;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        var p = rt.anchoredPosition;
        p.x -= Time.deltaTime * speed;
        rt.anchoredPosition = p;

        if (p.x < -3000)
        {
            Destroy(gameObject);
        }
    }
}
