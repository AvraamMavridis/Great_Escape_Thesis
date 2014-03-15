using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;

public class Main : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

        TcpListener listener = new TcpListener(IPAddress.Any, 5004);
        listener.Start();
        TcpClient client;
        while (true)
        {
            client = listener.AcceptTcpClient();
            if (client.Connected)
            {
                print("client connected");
                break;
            }

        }
    }
}