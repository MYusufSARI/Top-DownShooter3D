using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.UI
{
    public class Popup : MonoBehaviour
    {
        public bool IsOpen { get; set; }


        public void Open()
        {
            if (!IsOpen)
                return;

            gameObject.SetActive(true);

            OnOpened();
        }


        public void Close()
        {
            if (IsOpen)
                return;

            gameObject.SetActive(false);

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
