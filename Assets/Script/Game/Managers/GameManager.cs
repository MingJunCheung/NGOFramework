using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Transports.UTP;
using Unity.Netcode;
using UnityEngine;
using JetBrains.Annotations;
using Unity.Jobs;
using Unity.Collections;

public class GameManager : Single<GameManager>
{
    public LaucherType laucherType;

    public MonoBehaviour mono { get; private set; }

    JobHandle JobHandle;


    public void Init(MonoBehaviour mono)
    {
        this.mono = mono;
    }

    public void LauchGame(LaucherType laucherType)
    {
        this.laucherType= laucherType;

        NetworkManager.Singleton.OnServerStarted += OnServerStartUp;
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisConnected;
        MonoInstance.Instance.Init();

        this.mono.StartCoroutine(EnumeratorTest());


        if (laucherType == LaucherType.Host)
        {
            NetworkManager.Singleton.StartHost();
        }
        else if (laucherType == LaucherType.Client)
        {
            UIManager.Instance.Init();
            NetworkManager.Singleton.StartClient();

        }
        else if (laucherType == LaucherType.Server)
        {
            NetworkManager.Singleton.StartServer();
        }

        //InitNetComponentJob initNetComponentJob = new InitNetComponentJob();
        //InitTableJob initTableJob = new InitTableJob();
        //InitUIManagerJob initUIManagerJob = new InitUIManagerJob();

        //JobHandle = initUIManagerJob.Schedule();
    }

    public void StartClient()
    {

    }

    public void StartServer()
    {

    }

    private void OnClientConnected(ulong clientIndex)
    {
        Debug.Log($"{clientIndex}号客户端连接，当前连接客户端数量：{NetworkManager.Singleton.ConnectedClients.Count}");
        NetworkManager.Singleton.CustomMessagingManager.RegisterNamedMessageHandler(clientIndex.ToString(),MessagerManager.Instance.OnSendNamedMsg);
    }

    private void OnClientDisConnected(ulong clientIndex)
    {
        Debug.Log($"{clientIndex}号客户端断开连接，当前连接客户端数量：{NetworkManager.Singleton.ConnectedClients.Count}");
        NetworkManager.Singleton.CustomMessagingManager.UnregisterNamedMessageHandler(clientIndex.ToString());
    }

    private void OnServerStartUp()
    {
        Debug.Log($"服务器启动！ip:{NetworkManager.Singleton.GetComponentInParent<UnityTransport>().ConnectionData.Address}," +
            $"port:{NetworkManager.Singleton.GetComponentInParent<UnityTransport>().ConnectionData.Port}");
    }


    public IEnumerator EnumeratorTest()
    {
        Debug.Log("EnumeratorTest");
        yield break;
    }


    public struct InitNetComponentJob : IJob
    {
        public void Execute()
        {
            Debug.Log("初始化网络组建");
        }
    }

    public struct InitTableJob : IJob
    {
        public void Execute()
        {
            Debug.Log("初始化Table");
        }
    }

    public struct InitSDataJob : IJob
    {
        public void Execute()
        {
            Debug.Log("初始化SData");
        }
    }

    public struct InitUIManagerJob : IJob
    {
        public void Execute()
        {
            UIManager.Instance.Init();
        }
    }

}
