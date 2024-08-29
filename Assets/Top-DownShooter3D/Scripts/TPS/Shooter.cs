using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class Shooter : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private float _fireRate = 0.5f;
        [SerializeField] private float _accuracy = 1f;

        private float _lastShootTime;

        [Header(" Elements ")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _shootTransform;

        public bool CanShoot => Time.time > _lastShootTime + _fireRate;



        public void Shoot()
        {
            if (!CanShoot) return;

            var inst = Instantiate(_projectilePrefab, _shootTransform.position, _shootTransform.rotation);

            var rand = Random.value;
            var maxAngle = 60 - 60 * _accuracy;

            var randomAngle = Mathf.Lerp(-maxAngle, maxAngle, rand);

            var forward = inst.transform.forward;

            forward = Quaternion.Euler(0, randomAngle, 0) * forward;

            inst.transform.forward = forward;

            _lastShootTime = Time.time;
        }
    }
}
