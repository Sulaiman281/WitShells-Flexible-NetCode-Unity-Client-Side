using UnityEngine.Events;

namespace WitShells.Client.Tcp
{
    public class Client : TcpClientBase
    {
        public UnityAction onConnectedToServer;
        public UnityAction onDisconnectedFromServer;
        public UnityAction onFailedToConnectWithServer;
        public UnityAction<string> onReceiveMessage;

        public Client(string serverAddress, int port) : base(serverAddress, port)
        {
        }

        protected override void OnConnectedToServer()
        {
            onConnectedToServer?.Invoke();
        }

        protected override void OnDisconnectedFromServer()
        {
            onDisconnectedFromServer?.Invoke();
        }

        protected override void OnFailedToConnectWithServer()
        {
            onFailedToConnectWithServer?.Invoke();
        }

        protected override void OnReceiveMessage(string message)
        {
            onReceiveMessage?.Invoke(message);
        }
    }
}