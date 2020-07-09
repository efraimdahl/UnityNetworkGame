using UnityEngine;
/// <summary>
/// Class showing usage example.
/// Uses UI and server communication.
/// </summary>
public class UsageExample : MonoBehaviour
{
    // Reference to the servercommunication
    [SerializeField]
    private ServerCommunication communication;
    // Reference to UIForm
    [SerializeField]
    /// <summary>
    /// Unity method called after object initialization.
    /// </summary>
    private void Start()
    {
        communication.Lobby.OnConnectedToServer += OnConnectedToServer;
        communication.ConnectToServer();
    }
    /// <summary>
    /// Method called after connection with server was established.
    /// </summary>
    private void OnConnectedToServer()
    {
        communication.Lobby.OnConnectedToServer -= OnConnectedToServer;
        communication.Lobby.OnEchoMessage += OnReceivedEchoMessage;
    }
    /// <summary>
    /// Method called when Send button was clicked in form.
    /// Send echo message to the server.
    /// </summary>
    private void OnSendForm()
    {
        Debug.Log("Sending Request Message");
        var message = new EchoMessageModel
        {

            message = "hello",

        };
        communication.Lobby.EchoMessage(message);
        //uiForm.ClearInputField();
    }

    //When Room Request Button was pressed
    public void RequestRoom()
    {
        Debug.Log("Sending Request Message");
        communication.Lobby.RequestMessage();
        
    }
    /// <summary>
    /// Method called when server return echo message.
    /// </summary>
    /// <param name="message">Message.</param>
    private void OnReceivedEchoMessage(EchoMessageModel message)
    {
        Debug.Log("Echo message received: " + message.message);
        //uiForm.ShowServerResponse(message.text);
    }
    /// <summary>
    /// Unity method called when object is disabled.
    /// </summary>
    private void OnDisable()
    {
        communication.Lobby.OnConnectedToServer -= OnConnectedToServer;
        communication.Lobby.OnEchoMessage -= OnReceivedEchoMessage;
        //uiForm.OnSendButtonClicked -= OnSendForm;
    }
}