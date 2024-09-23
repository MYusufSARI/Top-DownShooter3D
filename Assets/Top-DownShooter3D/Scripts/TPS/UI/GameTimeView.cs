using System;
using TPS.MatchSystem;
using TMPro;
using UnityEngine;

namespace TPS.UI
{
    public class GameTimeView : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;

        [Header("Elements")]
        [SerializeField] private TMP_Text _text;



        private void Update()
        {
            var timeSpan = TimeSpan.FromSeconds(_matchInstance.Time);
            
            _text.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
