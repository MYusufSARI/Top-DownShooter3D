using System;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.UI.Pagination
{
    public class TabView : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Router _router;

        [Header("Elements")]
        [SerializeField] private PageTabButtonPair[] _pairs;


        
        [System.Serializable]
        public class PageTabButtonPair
        {
            public Page Page;
            public Button Button;
        }

        private void Awake()
        {
            foreach (var pair in _pairs)
            {
                pair.Button.onClick.AddListener(() =>
                {
                    // request router to open the page
                    _router.ActivePage = pair.Page;
                });
            }
        }
    }
}
