using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPS.MatchSystem;
using UnityEngine;
using UnityEngine.UI;

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

            _text.text = string.Format("{0:02}:{1:02}", timeSpan.Minutes, timeSpan.Seconds); 
        }
    }
}
