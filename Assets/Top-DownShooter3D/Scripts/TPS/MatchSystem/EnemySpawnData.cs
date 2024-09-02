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


        public bool TryGetEntryByTime(float time, out SpawnEntry spawnEntry)
        {
            float totalTime = 0f;

            foreach (var entry in _entries)
            {
                totalTime += entry.Duration;

                if (totalTime > time)
                {
                    spawnEntry = entry;
                    return true;
                }
            }

            spawnEntry = new SpawnEntry();
            return false;
        }
    }


    [System.Serializable]
    public struct SpawnEntry
    {
        [Header("Settings")]
        [SerializeField] private int _duration;
        [SerializeField] private int _spawnCount;

        public int Duration => _duration;
        public int SpawnCount => _spawnCount;

        [Header("Elements")]
        [SerializeField] private GameObject[] _prefabs;

        public GameObject[] Prefabs => _prefabs;
    }
}
