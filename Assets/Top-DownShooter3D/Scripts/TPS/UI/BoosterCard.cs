using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPS.BoosterSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TPS.UI
{
    public class BoosterCard : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClicked;

        [Header("Elements")]
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;

        [Header("Data")]
        private Booster _booster;

        public Booster Booster
        {
            get => _booster;
            set
            {
                _booster = value;

                UpdateUI();
            }
        }


        private void UpdateUI()
        {
            _title.text = _booster.BoosterName;

            _description.text = _booster.Description;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}
