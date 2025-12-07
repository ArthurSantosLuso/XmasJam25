using Behaviours;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitPlacing : MonoBehaviour
{
    [SerializeField] private Camera         _camera;
    [SerializeField] private GridManager    _gridManager;
    [SerializeField] private GameObject     _unitSelectionGroup;
    [SerializeField] private ViewManager    _viewManager;

    private GameObject _unitPrefab;

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        CheckForSelectedUnit();
        if (_unitPrefab == null)
            return;

        HandlePlaceUnit();
    }

    private void CheckForSelectedUnit()
    {
        foreach (Transform child in _unitSelectionGroup.transform)
        {
            UnitToggle unitToggle = child.GetComponent<UnitToggle>();

            if (unitToggle != null && unitToggle.Toggle.isOn)
            {
                _unitPrefab = unitToggle.UnitPrefab;
                return;
            }
        }

        _unitPrefab = null;
    }

    private void HandlePlaceUnit()
    {
        if (_unitPrefab == null) return;

        Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));

        Tile tile = _gridManager.GetTileAtPosition(gridPos);
        if (tile == null)
        {
            Debug.Log("Nenhum tile nesse local");
            return;
        }

        // Verificar se tem dinheiro o suficiente
        AllyStats data = _unitPrefab.GetComponent<AllyStats>();
        if(_viewManager.GetCurrentMoney() < data.GetUnitCost())
        {
            Debug.Log($"Não pode plantar. Sem dinheiro suficiente.");
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
            _viewManager.SpendMoney(data.GetUnitCost());
            Debug.Log($"Unidade colocada no tile {gridPos}");
            Debug.Log($"Dinheiro atual: {_viewManager.GetCurrentMoney()}");
        }
        else
        {
            Debug.Log("Falha ao colocar planta.");
        }

    }
}
