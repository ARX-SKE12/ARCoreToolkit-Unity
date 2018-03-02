using System.Collections.Generic;
using UnityEngine;
using SocketIO;

namespace LoggingClient
{

    public class LogClient : MonoBehaviour
    {

        #region Attribute
        SocketIOComponent socket;
        bool isReady;
        List<string> logQueue;
        #endregion

        #region Constants
        const string OPEN_CONNECTION_EVENT = "open";
        const string MSG_KEY = "msg";
        const string SOCKET_TAG = "log";
        public const string CLIENT_STATUS_TAG = "Client Status";
        const string CONNECTION_SUCCESSFUL_MSG = "Connection to Log Server is successful.";
        #endregion

        #region Singleton
        public static LogClient instance;

        void Awake()
        {
            if (!instance) instance = this;
            else if (instance != this) Destroy(gameObject);
            logQueue = new List<string>();
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Unity Behavior
        void Start()
        {
            socket = GameObject.FindObjectOfType<SocketIOComponent>();
            socket.On(OPEN_CONNECTION_EVENT, OnSocketOpen);
        }
        #endregion

        #region Log
        public void OnSocketOpen(SocketIOEvent e)
        {
            isReady = true;
            Log(CLIENT_STATUS_TAG, CONNECTION_SUCCESSFUL_MSG);
        }

        public void Log(string tag, string msg)
        {
            string logData = tag + ": " + msg;
            logQueue.Add(logData);
            if (isReady)
            {
                foreach (string logMsg in logQueue)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data[MSG_KEY] = logMsg;
                    socket.Emit(SOCKET_TAG, new JSONObject(data));
                }
                logQueue.Clear();
            }
        }
        #endregion

    }
}
