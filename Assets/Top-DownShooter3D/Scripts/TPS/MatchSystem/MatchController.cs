using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.MatchSystem
{
    public class MatchController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;

        [Header("Elements")]
        [SerializeField] private GameObject _player;



        private void Awake()
        {
            _matchInstance.Reset();

            _matchInstance.Player = _player;
        }


        private void Update()
        {
            _matchInstance.AddTime(Time.deltaTime);
        }
    }
}
