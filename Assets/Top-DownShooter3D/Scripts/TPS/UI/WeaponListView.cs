using TPS.WeaponSystem;
using UnityEngine;

namespace TPS.UI
{
    public class WeaponListView : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _weaponViewContainer;
        [SerializeField] private Weapon[] _weapons;

        [Header("UI")]
        [SerializeField] private WeaponPreviewButton _weaponPreviewButtonPrefab;



        private void Awake()
        {
            GenerateButtons();
        }


        private void Start()
        {
            CreateGraphics(_weapons[0]);
        }


        public void GenerateButtons()
        {
            foreach (Transform c in _container)
            {
                Destroy(c.gameObject);
            }

            foreach (var weapon in _weapons)
            {
                var inst = Instantiate(_weaponPreviewButtonPrefab, _container);
                inst.Weapon = weapon;
                inst.Clicked += () =>
                {
                    CreateGraphics(weapon);
                };
            }
        }


        private void CreateGraphics(Weapon weapon)
        {
            foreach (Transform child in _weaponViewContainer)
            {
                Destroy(child.gameObject);
            }

            var inst = Instantiate(weapon.WeaponGraphics, _weaponViewContainer);
            inst.transform.localPosition = Vector3.zero;
        }
    }
}
