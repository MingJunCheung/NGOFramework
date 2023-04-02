
using System;
using Unity.Collections;
using Unity.Netcode;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

public class UnnamedMessageHandler : CustomUnnamedMessageHandler<string>
{

    public UnnamedMessageHandler(NetworkManager netManager) : base(netManager)
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
        //var writer = new FastBufferWriter(1100, Allocator.Temp);
        var customMessagingManager = NetworkManager.Singleton.CustomMessagingManager;
        using (var _writer = new FastBufferWriter(FastBufferWriter.GetWriteSize<MessageBase>(), Allocator.Temp))
        {
            _writer.WriteValueSafe(new MessageBase() { msgType = 10000 });

            if (NetworkManager.Singleton.IsServer)
            {
                customMessagingManager.SendUnnamedMessageToAll(_writer);
            }
            else
            {
                // This method can be used by a client or server (client to server or server to client)
                customMessagingManager.SendUnnamedMessage(NetworkManager.ServerClientId, _writer);
            }
        }
    }

    public override void OnRevceivedUnNameMsg(ulong clientId, FastBufferReader reader)
    {
        MessageBase msg = new MessageBase();
        reader.ReadValueSafe(out msg);

        if (this.netManager.IsServer)
        {
            Debug.Log($"服务器收到{clientId}号客户端发来的消息:{msg.msgType}");
            //SendUnNamedMsg();
        }
        else
        {
            Debug.Log($"客户端收到{clientId}号服务器发来的消息:{msg.msgType}");
        }
    }
}