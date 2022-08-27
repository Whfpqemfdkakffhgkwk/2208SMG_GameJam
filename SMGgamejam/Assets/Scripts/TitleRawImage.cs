using UnityEngine;
using UnityEngine.UI;

public class TitleRawImage : MonoBehaviour
{
    [SerializeField]
    RawImage rawImage;
    
    void Update()
    {
        var rawImageUVRect = rawImage.uvRect;
        rawImageUVRect.x = Time.time;
        rawImage.uvRect = rawImageUVRect;
    }
}
