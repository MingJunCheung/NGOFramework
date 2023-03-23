using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class MessagerManager : Single<MessagerManager>
{
    public void OnRecievNamedMsg(ulong clientId, FastBufferReader messagePayload)
    {
        Debug.Log($"收到消息：{messagePayload.ToString()}");
    }

    public void OnSendNamedMsg(ulong clientId, FastBufferReader messagePayload)
    {
        Debug.Log($"收到消息：{messagePayload.ToString()}");
    }

    public void SendNamedMsg(ulong clientId)
    {
        FastBufferWriter messagePayload = new FastBufferWriter();
        messagePayload.WriteValueSafe(100);
        NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage("aaa", clientId, messagePayload);
    }

    public void SendUnNamedMsg(ulong clientId)
    {
        FastBufferWriter messagePayload = new FastBufferWriter();
        messagePayload.WriteValueSafe(100);
        NetworkManager.Singleton.CustomMessagingManager.SendUnnamedMessage( clientId, messagePayload);
    }

    /// <summary>
    /// 发消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    public void SendMessageThroughNetwork<T>(T message) where T : unmanaged,INetworkSerializeByMemcpy
    {
        var writer = new FastBufferWriter(FastBufferWriter.GetWriteSize<T>(), Allocator.Temp);
        writer.WriteValueSafe(message);
        string name = "";
        NetworkManager.Singleton.CustomMessagingManager.SendNamedMessageToAll(name, writer);
    }
}
