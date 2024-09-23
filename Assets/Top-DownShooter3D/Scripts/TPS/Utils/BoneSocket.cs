using UnityEngine;

namespace TPS.Utils
{
    public class BoneSocket : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _socketName;

        public string SocketName => _socketName;
    }
}
