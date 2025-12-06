using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite         baseSprite;
    [SerializeField] private Sprite         offsetSprite;
    [SerializeField] private GameObject     highlight;
    [SerializeField] private SpriteRenderer renderer;

    public void Init(bool isOffset)
    {
        
        if (!isOffset)
            renderer.sprite = baseSprite;
        else
            renderer.sprite = offsetSprite;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
