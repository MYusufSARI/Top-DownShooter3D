using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class Shooter : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private float _fireRate;

        private float _lastShootTime;

        [Header(" Elements ")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _shootTransform;

        public bool CanShoot => Time.time > _lastShootTime + _fireRate;



        public void Shoot()
        {
            if (!CanShoot) return;

            var inst = Instantiate(_projectilePrefab, _shootTransform.position, _shootTransform.rotation);

            _lastShootTime = Time.time;
        }
    }
}
