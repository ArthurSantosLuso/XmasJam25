using System.Runtime.CompilerServices;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite         baseSprite;
    [SerializeField] private Sprite         offsetSprite;
    [SerializeField] private GameObject     highlight;
    [SerializeField] private SpriteRenderer renderer;

    private GameObject placedUnit;

    public bool IsOccupied => placedUnit != null;

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

    // Mudar de 'game object' para a classe ou interface da unidade
    public bool PlaceUnit(GameObject unit)
    {
        if (IsOccupied) return false;

        placedUnit = Instantiate(unit, transform.position, Quaternion.identity);

        return true;
    }
}
