using System.Collections;
using System.Collections.Generic;
using TPS.Mediatiors;
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
            if (container.TryGetComponent<PlayerMediator>(out var mediator))
            {
                mediator.Attributes.AttackSpeed += _value;
            }
        }
    }
}
