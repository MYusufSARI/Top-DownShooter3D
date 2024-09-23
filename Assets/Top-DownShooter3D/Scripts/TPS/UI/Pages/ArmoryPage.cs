using TPS.UI.Pagination;
using UnityEngine;

namespace TPS.UI.Pages
{
    public class ArmoryPage : Page
    {
        [Header("Elements")]
        [SerializeField] private Animator _animator;


        protected override void OnOpened()
        {
            _animator.Play("Armory");
        }


        protected override void OnClosed()
        {

        }
    }
}
