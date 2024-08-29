using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPS.Editor
{
    [CustomEditor(typeof(Shooter))]
    public class ShooterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
