using TPS.BoosterSystem;
using UnityEditor;
using UnityEngine;

namespace TPS.BoosterSystem.Editor
{
    [CustomEditor(typeof(BoosterContainer))]
    public class BoosterContainerEditor : UnityEditor.Editor
    {
        [Header("Data")]
        private Booster _booster;


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _booster = EditorGUILayout.ObjectField(_booster, typeof(Booster), false) as Booster;

            if (GUILayout.Button("Add") && _booster)
            {
                (target as BoosterContainer).AddBooster(_booster);
            }
        }
    }
}
