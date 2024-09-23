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

        public SpawnEntry[] Entries => _entries;



        public bool TryGetEntryByTime(float time, out SpawnEntry spawnEntry)
        {
            if (_entries == null || _entries.Length == 0)
            {
                Debug.LogError("_entries is null or empty in EnemySpawnData");
                spawnEntry = new SpawnEntry();
                return false;
            }

            float totalTime = 0f;

            foreach (var entry in _entries)
            {
                if (entry.Prefabs == null || entry.Prefabs.Length == 0)
                {
                    Debug.LogError("entry.Prefabs is null or empty in one of the SpawnEntry elements.");
                    spawnEntry = new SpawnEntry();
                    return false;
                }

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
        [SerializeField] private int _duration;
        public int Duration => _duration;

        [SerializeField] private int _spawnCount;
        public int SpawnCount => _spawnCount;

        [SerializeField] private GameObject[] _prefabs;
        public GameObject[] Prefabs => _prefabs;
    }
}
