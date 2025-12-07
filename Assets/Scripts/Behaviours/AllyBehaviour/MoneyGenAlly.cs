using UnityEngine;
using System.Collections;

namespace Behaviours
{
    public class MoneyGenAlly : AllyStats
    {
        [SerializeField] private ViewManager viewManager;
        [SerializeField] private float moneyGenerated;
        [SerializeField] private float moneyGenGap;
        private bool _isActive = true;

        protected override void DoSomething()
        {
            if (_isActive)
                StartCoroutine(GenMoney());
        }

        private IEnumerator GenMoney()
        {
            _isActive = false;
            YieldInstruction wait = new WaitForSeconds(moneyGenGap);

            while (true)
            {
                viewManager.EarnMoney(moneyGenerated);
                Debug.Log($"{this.name} generated money. Current money: {viewManager.GetCurrentMoney()}");
                
                yield return wait;
            }
        }
    }
}