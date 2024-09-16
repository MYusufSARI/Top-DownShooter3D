using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.BoosterSystem
{
    public abstract class Booster : ScriptableObject
    {
        public abstract void OnAdded(BoosterContainer container);
    }
}
