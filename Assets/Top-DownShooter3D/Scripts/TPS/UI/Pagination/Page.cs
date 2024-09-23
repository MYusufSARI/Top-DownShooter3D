using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.UI.Pagination
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public abstract class Page : MonoBehaviour
    {
        [Header("Elements")]
        private Canvas _canvas;
        private GraphicRaycaster _raycaster;



        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent<GraphicRaycaster>();
        }


        public void Open()
        {
            _canvas.enabled = true;
            _raycaster.enabled = true;

            OnOpened();
        }


        public void Close()
        {
            _canvas.enabled = false;
            _raycaster.enabled = false;

            OnClosed();
        }

        protected abstract void OnOpened();

        protected abstract void OnClosed();

    }
}
