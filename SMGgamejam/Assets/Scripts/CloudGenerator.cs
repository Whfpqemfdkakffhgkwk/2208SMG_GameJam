using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    IEnumerator Start()
    {
        while (Application.isPlaying)
        {
            var go = new GameObject("Cloud", typeof(RectTransform));
            go.transform.SetParent(transform, false);
            go.AddComponent<Image>();
            go.AddComponent<Cloud>();
            var goRt = go.GetComponent<RectTransform>();
            goRt.sizeDelta = new Vector2(Random.Range(100, 300), Random.Range(100, 200));
            var p = goRt.anchoredPosition;
            p.y = Random.Range(-100, 100);
            goRt.anchoredPosition = p;
            
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        }
    }
}
