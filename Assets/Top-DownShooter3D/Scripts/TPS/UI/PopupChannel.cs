using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.UI
{
    public static class PopupChannel
    {
        [Header("Elements")]
        private static List<Popup> _popups = new List<Popup>();



        public static Popup GetPopup(string name)
        {
            foreach (var pop in _popups)
            {
                if (pop.Name == name)
                {
                    return pop;
                }
            }

            return null;
        }


        public static bool TryGetPopup(string name, out Popup popup)
        {
            foreach (var pop in _popups)
            {
                if (pop.Name == name)
                {
                    popup = pop;

                    return true;
                }
            }

            popup = null;

            return false;
        }
    }
}
