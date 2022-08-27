using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DummyPlayerGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject dummyPlayerPrefab;

    [SerializeField]
    Transform canvasParent;
    
    void Start()
    {
        var list = new List<Vector2>();
        for (var i = 0; i < 1000; i++)
        {
            list.Add(new Vector2(Random.Range(-5100, -1100), Random.Range(-500, 500)));
        }
        list = list.OrderByDescending(e => e.y).ToList();
        
        foreach (var p in list)
        {
            var dummyPlayer = Instantiate(dummyPlayerPrefab, canvasParent, false);
            var rt = dummyPlayer.GetComponent<RectTransform>();
            rt.anchoredPosition = p;
        }
    }

    public void EnableGroup()
    {
        canvasParent.gameObject.SetActive(true);
    }
}
