using System;
using TPS.Mediators;
using UnityEngine;

namespace TPS.BoosterSystem.Boosters
{
    [CreateAssetMenu(menuName = "Boosters/Damage")]
    public class DamageBooster : Booster
    {
        [Header("Settings")]
        [SerializeField] private float _value;



        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent<PlayerMediator>(out var mediator))
            {
                mediator.Attributes.Damage += _value;
            }
        }
    }
}