using System.Diagnostics;
using Unity.Netcode;
using UnityEngine;

public class CustomUnnamedMessageHandler<T>
{
    protected NetworkManager netManager;


    public CustomUnnamedMessageHandler(NetworkManager netManager)
    {
        this.netManager = netManager;
        OnNetWorkSpawn();
    }

    ~CustomUnnamedMessageHandler()
    {
        OnNetWorkDespawn();
    }


    public virtual byte MessageType()
    {
        return 1;
    }

    public virtual void OnNetWorkSpawn()
    {
        netManager.CustomMessagingManager.OnUnnamedMessage += ReceiveMsg;
    }

    public virtual void OnNetWorkDespawn()
    {
        netManager.CustomMessagingManager.OnUnnamedMessage -= ReceiveMsg;
    }

    public virtual void OnRevceivedUnNameMsg(ulong clientId, FastBufferReader reader)
    {

    }

    public virtual void SendUnNamedMsg(T msg)
    {

    }

    private void ReceiveMsg(ulong clientId, FastBufferReader reader)
    {
        OnRevceivedUnNameMsg(clientId,reader);
    }
}