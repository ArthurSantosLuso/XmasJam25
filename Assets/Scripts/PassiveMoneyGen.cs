using UnityEngine;
using System.Collections;

public class PassiveMoneyGen : MonoBehaviour
{
    [SerializeField] private float          _timeToGenerate;
    [SerializeField] private float          _amountToGenerate;
    [SerializeField] private ViewManager    _viewManager;

    private void Start()
    {
        StartCoroutine(StartGenerating());
    }

    private void Update()
    {
        Debug.Log(_viewManager.GetCurrentMoney());
    }

    private IEnumerator StartGenerating()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToGenerate);

            _viewManager.EarnMoney(_amountToGenerate);
        }
    }
}
