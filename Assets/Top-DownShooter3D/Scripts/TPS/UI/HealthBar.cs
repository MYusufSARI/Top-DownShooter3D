using System.Collections;
using System.Collections.Generic;
using TPS.Mediatiors;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private PlayerMediator _playerMediator;

        [Header("Elements")]
        [SerializeField] private Image _fillImage;



        private void Update()
        {
            var health = _playerMediator.Health / _playerMediator.Attributes.MaxHealth;

            _fillImage.fillAmount = health;
        }
    }
}