using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.MatchSystem
{
    [CreateAssetMenu(menuName = "EnemySpawnData")]
    public class EnemySpawnData : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private SpawnEntry[] _entries;
    }


    [System.Serializable]
    public struct SpawnEntry
    {
        [Header("Settings")]
        [SerializeField] private int duration;
        [SerializeField] private int _spawnCount;

        [Header("Elements")]
        [SerializeField] private GameObject[] _prefabs;
    }
}
