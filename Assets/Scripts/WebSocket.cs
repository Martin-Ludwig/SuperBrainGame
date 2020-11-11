using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WebSocket : MonoBehaviour
{
    public bool Enabled;

    public String Uri;

    private ClientWebSocket ws;

    public void Start()
    {
        if (Enabled)
        {
            ws = new ClientWebSocket();
            Debug.Log("Connecting to: " + Uri);
            connect();
        }
    }

    private async void connect()
    {
        Debug.Log("Connecting to: " + Uri);
        await ws.ConnectAsync(new System.Uri(Uri), CancellationToken.None);
        while (ws.State == WebSocketState.Connecting)
        {
            Debug.Log("Waiting to connect...");
            Task.Delay(50).Wait();
        }
        Debug.Log("Connect status: " + ws.State);
    }

}
