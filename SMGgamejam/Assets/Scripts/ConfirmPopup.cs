using UnityEngine;
using UnityEngine.UI;

public class ConfirmPopup : MonoBehaviour
{
    public static ConfirmPopup Instance;
    
    [SerializeField]
    Text messageText;

    [SerializeField]
    Subcanvas subcanvas;

    System.Action onYes;
    System.Action onNo;

    void Awake()
    {
        Instance = this;
    }

    public void Open(string message, System.Action inOnYes, System.Action inOnNo)
    {
        messageText.text = message;
        onYes = inOnYes;
        onNo = inOnNo;
        subcanvas.Open();
    }

    public void OnYesClick()
    {
        onYes.Invoke();
    }

    public void OnNoClick()
    {
        onNo.Invoke();
    }

    public void Close()
    {
        subcanvas.Close();
    }
}
