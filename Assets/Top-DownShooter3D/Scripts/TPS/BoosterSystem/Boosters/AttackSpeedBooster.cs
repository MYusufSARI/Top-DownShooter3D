using TPS.Mediators;
using UnityEngine;

namespace TPS.BoosterSystem.Boosters
{
	[CreateAssetMenu(menuName = "Boosters/Attack Speed")]
    public class AttackSpeedBooster : Booster
    {
        [Header("Settings")]
        [SerializeField] private float _value;



        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent(out PlayerMediator mediator))
            {
                mediator.Attributes.AttackSpeed += _value;
            }
        }
    }
}
