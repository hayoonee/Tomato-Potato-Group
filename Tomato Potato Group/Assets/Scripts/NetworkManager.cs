using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";

    public TMPro.TMP_InputField usernameInput;
    public TMPro.TMP_Text buttonText;

  
    public void ClickConnect()
    {
        if(usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene(1);
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
}