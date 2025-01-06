using UnityEngine;
using WitShells.Enums;

namespace WitShells
{
    [CreateAssetMenu(fileName = "NetworkSettings", menuName = "Scriptable Objects/NetworkSettings")]
    public class NetworkSettings : ScriptableObject
    {
        private static NetworkSettings instance;

        public static NetworkSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<NetworkSettings>("NetworkSettings");
                }

                return instance;
            }
        }

        [Header("Settings")]
        [SerializeField] private ServerType serverType;
        [SerializeField] private string serverAddress;

        [Header("UDP Connection Settings")]

        [Header("Tcp Connection Settings")]
        public ushort tcpPort = 9901;

        public bool HasServerAddress => !string.IsNullOrEmpty(serverAddress);

        public string ServerAddress
        {
            get
            {
                if (string.IsNullOrEmpty(serverAddress))
                {
                    Debug.LogError("Server Address is not set. Please set the server address.");
                }

                return serverAddress;
            }
        }

        public void SaveIdentity()
        {
            PlayerPrefs.Save();
        }

        public bool HasIdentity(ref string identity)
        {
            if (PlayerPrefs.HasKey("UniqueIdentifier"))
            {
                identity = PlayerPrefs.GetString("UniqueIdentifier");
                return true;
            }
            return false;
        }
    }
}