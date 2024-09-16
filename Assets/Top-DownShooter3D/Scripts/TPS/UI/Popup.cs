using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.UI
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class Popup : MonoBehaviour
    {
        [Header("Elements")]
        private Canvas _canvas;
        private GraphicRaycaster _raycaster;

        public bool IsOpen => _canvas.enabled;


        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent<GraphicRaycaster>();
        }


        public void Open()
        {
            if (!IsOpen)
                return;

            _canvas.enabled = true;
            _raycaster.enabled = true;

            OnOpened();
        }


        public void Close()
        {
            if (IsOpen)
                return;

            _canvas.enabled = false;
            _raycaster.enabled = false;

            OnClosed();
        }

        protected virtual void OnOpened()
        {

        }


        protected virtual void OnClosed()
        {

        }
    }
}
