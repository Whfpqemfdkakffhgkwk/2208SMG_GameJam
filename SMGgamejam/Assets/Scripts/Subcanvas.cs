using UnityEngine;
using UnityEngine.UI;

public class Subcanvas : MonoBehaviour
{
    [SerializeField]
    CanvasGroup canvasGroup;

    [SerializeField]
    Image image;

    [SerializeField]
    Animator animator;

    static readonly int OpenHash = Animator.StringToHash("Open");
    static readonly int CloseHash = Animator.StringToHash("Close");

    public void Open()
    {
        var imageColor = image.color;
        imageColor.a = 0.5f;
        image.color = imageColor;
        
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        if (animator != null)
        {
            animator.Play("Popup Opening");
        }
        
        
    }

    public void Close()
    {
        //canvasGroup.alpha = 0;
        var imageColor = image.color;
        imageColor.a = 0.0f;
        image.color = imageColor;
        
        canvasGroup.blocksRaycasts = false;

        if (animator != null)
        {
            animator.Play("Popup Closing");
        }
    }
}
