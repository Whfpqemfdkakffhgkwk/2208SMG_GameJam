using UnityEngine;

public class Cloud : MonoBehaviour
{
    RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        var p = rt.anchoredPosition;
        p.x -= Time.deltaTime * 100;
        rt.anchoredPosition = p;

        if (p.x < -3000)
        {
            Destroy(gameObject);
        }
    }
}
