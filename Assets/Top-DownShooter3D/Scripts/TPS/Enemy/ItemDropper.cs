using DG.Tweening;
using TPS.WeaponSystem;
using TPS;
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
        [SerializeField] private WeaponCollectable _weaponCollectiblePrefab;

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
                    
                    inst.transform.DOJump(transform.position + randomPointOnCircle * 5, 1, 1, .4f);
                    break;
                }
            }
        }

        [System.Serializable]
        public class WeaponDropChance
        {
            public float Chance;
            public Weapon Weapon;
        }
    }
}
