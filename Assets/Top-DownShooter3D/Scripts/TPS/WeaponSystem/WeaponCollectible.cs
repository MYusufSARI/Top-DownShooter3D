using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TPS.WeaponSystem
{
    public class WeaponCollectible : MonoBehaviour
    {
        [Header(" Data ")]
        [SerializeField] private Weapon _weapon;



        private void Start()
        {
            var inst = Instantiate(_weapon.WeaponGraphics, transform);

            inst.transform.localPosition = Vector3.zero;
            inst.transform.DORotate(Vector3.up * 360, 1f, RotateMode.WorldAxisAdd).SetLoops(-1). SetEase(Ease.Linear);
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
