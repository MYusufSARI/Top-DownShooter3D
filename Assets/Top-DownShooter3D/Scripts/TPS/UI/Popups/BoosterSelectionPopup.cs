using System.Collections;
using System.Collections.Generic;
using TPS.BoosterSystem;
using TPS.UI;
using UnityEngine;

namespace TPS.UI
{
    public class BoosterSelectionPopup : Popup
    {
        [Header("Data")]
        [SerializeField] private BoosterList _boosterList;
        [SerializeField] private BoosterCard _boosterCardPreab;

        [Header("Elements")]
        [SerializeField] private Transform _container;



        private void Start()
        {
            Open();
        }


        protected override void OnOpened()
        {
            base.OnOpened();

            for (int i = 0; i < 3; i++)
            {
                var randomBooster = _boosterList.Get(Random.Range(0, _boosterList.Length));

                var inst = Instantiate(_boosterCardPreab, _container);
                inst.Booster = randomBooster;
            }
        }
    }
}
