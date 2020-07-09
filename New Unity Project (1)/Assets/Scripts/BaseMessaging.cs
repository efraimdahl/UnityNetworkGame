using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for messaging groups.
/// </summary>
public class BaseMessaging
{
    // Reference to the server communication.
    protected ServerCommunication client;
    /// <summary>
    /// Initializes a new instance of the <see cref="T:BaseMessaging"/> class.
    /// </summary>
    //<param name="client">Client.</param>
    /// 
    public const string Register = "register";
    public UnityAction OnConnectedToServer;
    public BaseMessaging(ServerCommunication client)
    {
        this.client = client;


    }
    public const string Echo = "echo";
    public UnityAction<EchoMessageModel> OnEchoMessage;
    /// <summary>
    /// Sends echo message to the server.
    /// </summary>
    /// <param name="request">Request.</param>
    public void EchoMessage(EchoMessageModel request)
    {
        var message = new MessageModel
        {
            method = "echo",
            message = JsonUtility.ToJson(request)
        };
        client.SendRequest(JsonUtility.ToJson(message));
    }
    public const string Request = "request";
    public UnityAction<MessageModel> OnRequestMessage;
    public void RequestMessage()
    {
        Debug.Log("Formulating Request Message");
        var message = new MessageModel
        {
            nickname = "host",
            roomCode = "ABCD",
            messageType = "CREATE_ROOM_REQUEST",
            method = "request",
            message = ""
        };
        client.SendRequest(JsonUtility.ToJson(message));
    }

    public const string Server_Back = "request";
    public UnityAction<MessageModel> OnServerRoomResponse;
    public void ServerRoomResponse()
    {
        Debug.Log("Formulating Request Message");
        var message = new MessageModel
        {
            nickname = "host",
            roomCode = "ABCD",
            messageType = "CREATE_ROOM_REQUEST",
            method = "request",
            message = ""
        };
    }

}

