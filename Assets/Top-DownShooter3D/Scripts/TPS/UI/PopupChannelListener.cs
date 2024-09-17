using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.UI
{
    public class PopupChannelListener : MonoBehaviour
    {
        [Header("Data")]
        private Popup _popup;



        private void Awake()
        {
            _popup = GetComponent<Popup>();
        }


        private void OnEnable()
        {
            PopupChannel.RegisterPopup(_popup);
        }


        private void OnDisable()
        {
            PopupChannel.UnRegisterPopup(_popup);
        }
    }
}
