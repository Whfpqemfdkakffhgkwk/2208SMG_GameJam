using UnityEngine;

public class Subcanvas : MonoBehaviour
{
    [SerializeField]
    CanvasGroup canvasGroup;

    [SerializeField]
    Animator animator;

    static readonly int OpenHash = Animator.StringToHash("Open");
    static readonly int CloseHash = Animator.StringToHash("Close");

    public void Open()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        if (animator != null)
        {
            animator.SetTrigger(OpenHash);
        }
    }

    public void Close()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;

        if (animator != null)
        {
            animator.SetTrigger(CloseHash);
        }
    }
}
