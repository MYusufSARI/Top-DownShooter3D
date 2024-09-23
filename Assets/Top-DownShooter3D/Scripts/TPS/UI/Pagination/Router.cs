using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.UI.Pagination
{
    public class Router : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private List<Page> _pages = new List<Page>();


        private Page _activePage;
        public Page ActivePage
        {
            get => _activePage;

            set
            {
                if (_activePage)
                {
                    _activePage.Close();
                }

                _activePage = value;

                if (_activePage)
                {
                    _activePage.Open();
                }
            }
        }


        private void Start()
        {
            foreach (var page in _pages)
            {
                page.Close();
            }

            if (_pages.Count > 0)
            {
                ActivePage = _pages[0];
            }

        }


        public void SetPage<T>() where T : Page
        {
            foreach (var page in _pages)
            {
                if (page is T caster)
                {
                    ActivePage = page;
                    return;
                }
            }
        }
    }
}
