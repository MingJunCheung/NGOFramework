using System.Collections;
using System.Collections.Generic;
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
}
