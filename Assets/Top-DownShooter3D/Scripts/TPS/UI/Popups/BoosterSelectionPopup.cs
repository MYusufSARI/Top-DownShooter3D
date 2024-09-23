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

        public BoosterContainer TargetBoosterContainer { get; set; }

        [Header("Elements")]
        [SerializeField] private Transform _container;



        protected override void OnOpened()
        {
            Time.timeScale = 0;

            foreach (Transform c in _container)
            {
                Destroy(c.gameObject);
            }

            for (int i = 0; i < 3; i++)
            {
                var randomBooster = _boosterList.Get(Random.Range(0, _boosterList.Length));

                var inst = Instantiate(_boosterCardPreab, _container);
                inst.Booster = randomBooster;

                inst.OnClicked += () =>
                {
                    TargetBoosterContainer.AddBooster(inst.Booster);

                    Close();
                };
            }
        }


        protected override void OnClosed()
        {
            Time.timeScale = 1;
        }
    }
}
