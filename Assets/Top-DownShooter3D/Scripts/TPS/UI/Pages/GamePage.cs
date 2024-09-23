using System;
using System.Collections;
using System.Collections.Generic;
using TPS.UI.Pagination;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TPS.UI.Pages
{
    public class GamePage : Page
    {
        [Header("Elements")]
        [SerializeField] private Button _playButton;



        protected override void OnOpened()
        {
            _playButton.onClick.AddListener(OnPlayButtonPressed);
        }
    

        protected override void OnClosed()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonPressed);
        }


        private void OnPlayButtonPressed()
        {
            SceneManager.LoadScene(1)
        }
    }
}