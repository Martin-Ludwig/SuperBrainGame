using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using UnityEngine;

public class BciController : MonoBehaviour
{
    public WebSocket ws;
    public BciControllerState State => _state;
    public BciMentalInput Input => _input;

    private BciMentalInput _input;

    private BciControllerState _state = BciControllerState.Disabled;

    // Start is called before the first frame update
    void Start()
    {
        _state = BciControllerState.Disabled;
        if (ws.Enabled)
        {
            _state = BciControllerState.Connecting;
            ws.Connect();
            _input = new BciMentalInput();

            _state = BciControllerState.Connected;
            Listen();
        }
    }

    private async void Listen()
    {
        if (ws.Enabled && ws.State == WebSocketState.Open)
        {
            string msg = await ws.Listen();

            try
            {
                _input = JsonUtility.FromJson<BciMentalInput>(msg);
                print($"input parsed to: {_input}");
            }
            catch (Exception e)
            {
                throw new Exception($"Could not convert data to BCI Input.\n data = {msg}\n {e}");
            }
        }
        if (ws.Enabled)
        {
            await Task.Delay(50);
            Listen();
        }
    }

    public enum BciControllerState
    {
        Disabled,
        Connecting,
        Connected
    }

}
