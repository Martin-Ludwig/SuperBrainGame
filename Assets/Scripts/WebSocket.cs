using JetBrains.Annotations;
using System;
using System.Collections.Concurrent;
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
    private ConcurrentQueue<string> incMessages = new ConcurrentQueue<string>();
    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

    public void Start()
    {
        if (Enabled)
        {
            ws = new ClientWebSocket();
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
        
        if (ws.State == WebSocketState.Open)
        {
            Debug.Log("Listen...");
            listen();
        }
    }

    private async void listen()
    {
        if (ws.State == WebSocketState.Open)
        {

            buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult bytesIn = await ws.ReceiveAsync(buffer, CancellationToken.None);
            String msg = Encoding.UTF8.GetString(buffer.Array, 0, bytesIn.Count);
            Debug.Log(msg);
            
            listen();
        }
    }

    void OnApplicationQuit()
    {
        close();
    }

    private async void close()
    {
        try
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing app.", CancellationToken.None);
            Debug.Log("WebSocket connection closed.");
        } catch(Exception e)
        {
            
        }
    }

}
