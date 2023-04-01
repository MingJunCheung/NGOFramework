
using System;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class UnnamedMessageHandler :CustomUnnamedMessageHandler<string>
{

    public UnnamedMessageHandler(NetworkManager netManager):base(netManager)
    {
    }


    public override byte MessageType()
    {
        return base.MessageType();
    }

    public override void OnNetWorkSpawn()
    {
        base.OnNetWorkSpawn();
    }

    public override void OnNetWorkDespawn()
    {
        base.OnNetWorkDespawn();
    }

    public override void SendUnNamedMsg(string dataToSend)
    {
        var writer = new FastBufferWriter(1100, Allocator.Temp);
        var customMessagingManager = NetworkManager.Singleton.CustomMessagingManager;
        using (writer)
        {
            writer.WriteValueSafe(MessageType());

            writer.WriteValueSafe(dataToSend);
            if (NetworkManager.Singleton.IsServer)
            {
                customMessagingManager.SendUnnamedMessageToAll(writer);
            }
            else
            {
                // This method can be used by a client or server (client to server or server to client)
                customMessagingManager.SendUnnamedMessage(NetworkManager.ServerClientId, writer);
            }
        }
    }

    public override void OnRevceivedUnNameMsg(ulong clientId, FastBufferReader reader)
    {
        var messageType = (byte)1;
        reader.ReadValueSafe(out messageType);
        var stringMessage = string.Empty;
        reader.ReadValueSafe(out stringMessage);

        if (this.netManager.IsServer)
        {
            Debug.Log($"服务器收到{clientId}号客户端发来的消息:{stringMessage}");
        }
        else
        {
            Debug.Log($"客户端收到{clientId}号服务器发来的消息:{stringMessage}");
        }
    }
}