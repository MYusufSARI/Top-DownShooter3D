using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Tests
{
    public class ShooterTest : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private GameObject _projectilePrefab;



        private void Start()
        {
            StartCoroutine(Shooter());
        }


        private IEnumerator Shooter()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);

                Instantiate(_projectilePrefab, transform.position, transform.rotation);
            }
        }
    }
}
