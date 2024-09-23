using TPS.Mediators;
using TPS.UI.Pagination;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TPS.UI.Pages
{
    public class GamePage : Page
    {
        [Header("Elements")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Animator _animator;



        protected override void OnOpened()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);

            _animator.Play("Game");
        }


        protected override void OnClosed()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }


        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
