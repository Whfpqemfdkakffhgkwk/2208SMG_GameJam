using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DummyPlayer : MonoBehaviour
{
    [SerializeField]
    Sprite[] playerSpriteList;

    [SerializeField]
    Image image;

    [SerializeField]
    RectTransform rt;
    
    void Update()
    {
        image.sprite = playerSpriteList[Random.Range(0, 2)];
        var p = rt.anchoredPosition;
        p.x += Time.deltaTime * 1500;
        rt.anchoredPosition = p;

        if (p.x > 1000)
        {
            Destroy(gameObject);
            
            SceneManager.LoadScene("Main");
        }
    }
}
