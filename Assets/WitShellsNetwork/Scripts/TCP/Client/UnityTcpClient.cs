using UnityEngine;

namespace WitShells.Client.Tcp
{
    public class UnityTcpClient : MonoSingleton<UnityTcpClient>
    {

#if UNITY_EDITOR

        void OnGUI()
        {
            if (!NetworkSettings.Instance.HasServerAddress) return;

            if (_client == null)
            {
                if (GUI.Button(new Rect(10, 10, 150, 100), "Connect"))
                {
                    Connect(NetworkSettings.Instance.ServerAddress, NetworkSettings.Instance.tcpPort);
                }

                return;
            }

            if (_client.IsRunning)
            {
                if (GUI.Button(new Rect(10, 10, 150, 100), "Disconnect"))
                {
                    _client.Stop();
                }
            }
            else
            {
                if (GUI.Button(new Rect(10, 10, 150, 100), "Connect"))
                {
                    Connect(NetworkSettings.Instance.ServerAddress, NetworkSettings.Instance.tcpPort);
                }
            }
        }

#endif

        private Client _client = null;

        #region  Mono Cycle

        private void Start()
        {
        }

        private void FixedUpdate()
        {
            if (_client == null) return;

            _client.Updates();
        }

        #endregion

        public void Connect(string serverAddress, int port)
        {
            _client = new Client(serverAddress, port);

            _client.onConnectedToServer += ConnectedToServer;
            _client.onFailedToConnectWithServer += FailedToConnectWithServer;
            _client.onDisconnectedFromServer += DisconnectedFromServer;
            _client.onReceiveMessage += ReceiveMessage;
        }


        #region TCP Events

        private void ConnectedToServer()
        {
            Debug.Log("Connected to server");
        }

        private void FailedToConnectWithServer()
        {
            Debug.Log("Failed to connect with server");
        }

        private void DisconnectedFromServer()
        {
            Debug.Log("Disconnected from server");
        }

        private void ReceiveMessage(string message)
        {
            Debug.Log("Received message: " + message);
        }

        #endregion
    }
}