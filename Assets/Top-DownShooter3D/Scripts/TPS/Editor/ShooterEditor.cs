using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TPS.WeaponSystem;

namespace TPS.Editor
{
    [CustomEditor(typeof(Shooter))]
    public class ShooterEditor : UnityEditor.Editor
    {
        [Header(" Data ")]
        private Weapon _weapon;



        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _weapon = EditorGUILayout.ObjectField(_weapon, typeof(Weapon)) as Weapon;



            if(GUILayout.Button("Switch Weapon"))
            {
                var shooter = target as Shooter;

                shooter.EquipWeapon(_weapon);
            }
        }
    }
}
