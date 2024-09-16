using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.BoosterSystem
{
    public class BoosterContainer : MonoBehaviour
    {
        public event Action<Booster> OnBoosterAdded;

        [Header("Elements")]
        private List<Booster> _boosters = new List<Booster>();

        


        public void AddBooster(Booster booster)
        {
            _boosters.Add(booster);

            booster.OnAdded(this);
        }
    }
}
