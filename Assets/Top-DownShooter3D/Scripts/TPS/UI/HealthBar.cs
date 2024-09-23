using TPS.Mediators;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.UI
{
    public class Healthbar : MonoBehaviour
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
