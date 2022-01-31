using System.Collections;
using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public string NickName { get; internal set; }
    [SyncVar(hook = nameof(OnWelcomeCountChanged))]
    int welcomeCount = 0;

    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
        }
    }

     void Update()
    {
        HandleMovement();

        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Lets Play!");
            Welcome();
        }
    }

    public override void OnStartServer()
    {
        Debug.Log("Player has been spawned on the server!");
    }

    [Command]
    void Welcome()
    {
        Debug.Log("Received Greetings from Client!");
        welcomeCount += 1;
        ReplyWelcome();
       
    }

    [TargetRpc]
    void ReplyWelcome()
    {
        Debug.Log("Current Player, Make your move");
    }


    void OnWelcomeCountChanged(int oldCount, int newCount)
    {
        Debug.Log($"Player 1 played round {oldCount} , Round {newCount} is now your turn player!");
    }

}
