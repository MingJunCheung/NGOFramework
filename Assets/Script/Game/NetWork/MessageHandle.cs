
public class MessageHandle
{
    public string name;
    public string clientId;

    public MessageHandle(string clientId)
    {
        this.clientId = clientId;
        name = $"handle{clientId}";
    }

    public virtual void SendMessage()
    {

    }
}