using UnityEngine;

public class PlayerSpriteFlipper : MonoBehaviour
{
    int index;
    
    [SerializeField]
    Sprite[] spriteList;

    [SerializeField]
    SpriteRenderer targetRenderer;

    void Start()
    {
        Flip();
    }

    public void Flip()
    {
        if (spriteList.Length == 0)
        {
            Debug.LogError("Empty sprite list");
            return;
        }

        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer null");
            return;
        }
        
        targetRenderer.sprite = spriteList[index];
        index = (index + 1) % spriteList.Length;
    }
}
