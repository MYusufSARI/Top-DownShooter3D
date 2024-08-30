using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPS.WeaponSystem;

namespace TPS
{
    public class Shooter : MonoBehaviour
    {
        [Header(" Settings ")]
        private float _recoilValue = 0f;
        private float _lastShootTime;

        [Header(" Data ")]
        [SerializeField] private Weapon _weapon;

        private WeaponGraphics _activeWeaponGraphics;

        [Header(" Elements ")]
        [SerializeField] private GameObject _defaultProjectilePrefab;
        [SerializeField] private Transform _shootTransform;
        [SerializeField] private Transform _weaponContainer;

        public bool CanShoot => Time.time > _lastShootTime + _weapon.FireRate;
        


        private void Start()
        {
            if (_weapon) CreateGraphics();
        }


        public void EquipWeapon(Weapon weapon)
        {
            if (_activeWeaponGraphics)
            {
                ClearGraphics();
            }

            _weapon = weapon;

            if (weapon)
            {
                CreateGraphics();
            }
        }


        private void CreateGraphics()
        {
            if (!_weapon) return;

            var instance = Instantiate(_weapon.WeaponGraphics, _weaponContainer);
            instance.transform.localPosition = Vector3.zero;

            _activeWeaponGraphics = instance;
        }


        private void ClearGraphics()
        {
            if (!_activeWeaponGraphics) return;

            Destroy(_activeWeaponGraphics.gameObject);

            _activeWeaponGraphics = null;
        }


        public void Shoot()
        {
            if (!_weapon) return;

            if (!CanShoot) return;

            var projectileToInstantiate = _defaultProjectilePrefab;

            if (_weapon.ProjectilePrefab)
            {
                projectileToInstantiate = _weapon.ProjectilePrefab;
            }

            var inst = Instantiate(projectileToInstantiate, _activeWeaponGraphics.ShootTransform.position, _activeWeaponGraphics.ShootTransform.rotation);

            var rand = Random.value;
            var maxAngle = 30 - 30 * Mathf.Max(_weapon.Accuracy - _recoilValue, 0);

            var randomAngle = Mathf.Lerp(-maxAngle, maxAngle, rand);

            var forward = inst.transform.forward;

            forward = Quaternion.Euler(0, randomAngle, 0) * forward;

            inst.transform.forward = forward;

            _lastShootTime = Time.time;

            _recoilValue += _weapon.Recoil;
        }


        private void Update()
        {
            if (!_weapon) return;

            _recoilValue = Mathf.MoveTowards(_recoilValue, 0, _weapon.RecoilFade * Time.deltaTime);
        }
    }
}
