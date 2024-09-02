using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private float _baseDamage;
        [SerializeField] private float _fireRate = 0.5f;
        [SerializeField] private float _accuracy = 1f;
        [SerializeField] private float _recoil;
        [SerializeField] private float _recoilFade;

        [Header("Elements")]
        [SerializeField] private GameObject _projectilePrefab;

        [Header("Data")]
        [SerializeField] private WeaponGraphics _weaponGraphics;

        public float FireRate => _fireRate;
        public float Accuracy => _accuracy;
        public float Recoil => _recoil;
        public float RecoilFade => _recoilFade;
        public float BaseDamage => _baseDamage;

        public GameObject ProjectilePrefab => _projectilePrefab;

        public WeaponGraphics WeaponGraphics => _weaponGraphics;
    }
}
