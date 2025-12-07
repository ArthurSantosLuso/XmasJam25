using UnityEngine;
using UnityEngine.UI;


public class UnitToggle : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    private Toggle toggle;

    public GameObject UnitPrefab => unitPrefab;
    public Toggle Toggle => toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

}
