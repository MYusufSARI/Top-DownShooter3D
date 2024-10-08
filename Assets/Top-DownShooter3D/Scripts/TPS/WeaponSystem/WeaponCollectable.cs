using System;
using DG.Tweening;
using TPS.WeaponSystem;
using UnityEngine;

namespace TPS.WeaponSystem
{
    public class WeaponCollectable : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Weapon _weapon;

        public Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }



        private void Start()
        {
            var inst = Instantiate(_weapon.WeaponGraphics, transform);
            inst.transform.localPosition = Vector3.up;
            
            inst.transform.DORotate(Vector3.up * 360, 1f, RotateMode.WorldAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Shooter>(out var shooter))
            {
                shooter.EquipWeapon(_weapon);
                Destroy(gameObject);
            }
        }
    }
}
