using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using UnityEngine;

public class BciController : MonoBehaviour
{
    public WebSocket ws;
    public float rate;

    private BciMentalInput input;

    // Start is called before the first frame update
    void Start()
    {
        if (ws.Enabled)
        {
            ws.Connect();
            input = new BciMentalInput();

            Listen();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        
    }

    private async void Listen()
    {
        if (ws.Enabled && ws.State == WebSocketState.Open)
        {
            string msg = await ws.Listen();

            try
            {
                input = JsonUtility.FromJson<BciMentalInput>(msg);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not convert data to BCI Input.\n data = {msg}\n {e}");
            }

        }
        if (ws.Enabled)
        {
            Listen();
        }
    }

}
