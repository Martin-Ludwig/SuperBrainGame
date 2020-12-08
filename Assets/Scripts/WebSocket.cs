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

    public WebSocketState State { get { return ws.State; } }

    private ClientWebSocket ws = new ClientWebSocket();
    private ConcurrentQueue<string> incMessages = new ConcurrentQueue<string>();
    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
    private CancellationTokenSource cts = new CancellationTokenSource();

    void Start()
    {
        
    }

    /// <summary>
    /// Sets up a connection.
    /// </summary>
    public async void Connect()
    {
        Debug.Log("Connecting to: " + Uri);

        cts.Token.ThrowIfCancellationRequested();
        await ws.ConnectAsync(new System.Uri(Uri), cts.Token);
        while (ws.State == WebSocketState.Connecting)
        {
            Debug.Log("Waiting to connect...");
            Task.Delay(1000).Wait();
        }
        Debug.Log("Connect status: " + ws.State);
    }

    /// <summary>
    /// Returns incoming messages.
    /// </summary>
    /// <returns>String</returns>
    public async Task<string> Listen()
    {
        if (ws.State == WebSocketState.Open)
        {
            Debug.Log("Listen...");

            buffer = new ArraySegment<byte>(new byte[1024]);

            WebSocketReceiveResult bytesIn = await ws.ReceiveAsync(buffer, cts.Token);
            String msg = Encoding.UTF8.GetString(buffer.Array, 0, bytesIn.Count);
            
            Debug.Log($"Received: \n{msg}");

            return msg;
        }
        else
        {
            throw WebSocketException("WebSocket state is not open.");
        }
    }

    /// <summary>
    /// Closes the WebSocket connection.
    /// </summary>
    public async void Close()
    {
        if (ws != null && ws.State == WebSocketState.Open)
        {
            try
            {
                cts.Cancel();
                await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing app.", CancellationToken.None);
                Debug.Log("WebSocket connection closed.");
            }
            catch (Exception)
            {
                throw new WebSocketException("Failed to close connection.");
            }
        }
    }

    void OnApplicationQuit()
    {
        Close();
    }

    private Exception WebSocketException(string v)
    {
        throw new Exception(v);
    }

}
