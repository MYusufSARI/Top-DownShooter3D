using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TPS.WeaponSystem;
using UnityEngine;

namespace TPS
{
    public class ItemDropper : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _xp;
        [SerializeField, Range(0, 1)] private float _xpDropChange;

        [Header("Data")]
        [SerializeField] private WeaponDropChance[] _weaponDropChances;
        [SerializeField] private XPCollectable _xpCollectablePrefab;
        [SerializeField] private WeaponCollectible _weaponCollectiblePrefab;



        public void OnDied()
        {
            if (_xpCollectablePrefab && Random.value < _xpDropChange)
            {
                var inst = Instantiate(_xpCollectablePrefab, transform.position, Quaternion.identity);

                inst.XP = _xp;
            }

            foreach (var weaponDrop in _weaponDropChances)
            {
                if (Random.value < weaponDrop.Chance)
                {
                    var inst = Instantiate(_weaponCollectiblePrefab, transform.position, Quaternion.identity);
                    inst.Weapon = weaponDrop.Weapon;

                    Vector3 randomPointOnCircle = Random.insideUnitCircle;
                    randomPointOnCircle.z = randomPointOnCircle.y;
                    randomPointOnCircle.y = 0;

                    randomPointOnCircle.Normalize();

                    inst.transform.DOJump(transform.position + randomPointOnCircle * 5, 1, 1, .04f);
                    break;
                }
            }
        }
    }

    [System.Serializable]
    public class WeaponDropChance
    {
        public Weapon Weapon;

        public float Chance;
    }
}
