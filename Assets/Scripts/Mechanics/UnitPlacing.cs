using Unity.VisualScripting;
using UnityEngine;

public class UnitPlacing : MonoBehaviour
{
    [SerializeField] private Camera         _camera;
    [SerializeField] private GridManager    _gridManager;
    [SerializeField] private GameObject     _unitPrefab;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandlePlaceUnit();
        }
    }

    private void HandlePlaceUnit()
    {
        Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));

        Tile tile = _gridManager.GetTileAtPosition(gridPos);
        if (tile == null)
        {
            Debug.Log("Nenhum tile nesse local");
            return;
        }

        if (tile.IsOccupied)
        {
            Debug.Log("Tile já está ocupado!");
            return;
        }


        bool success = tile.PlaceUnit(_unitPrefab);
        if (success)
        {
            Debug.Log($"Planta colocada no tile {gridPos}");
        }
        else
        {
            Debug.Log("Falha ao colocar planta.");
        }

    }
}
