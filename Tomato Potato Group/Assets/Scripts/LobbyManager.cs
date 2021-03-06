using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class LobbyManager : MonoBehaviourPunCallbacks
    {
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomName roomNamePrefab;
    List<RoomName> roomNameList = new List<RoomName>();
    public Transform contentObject;

    public GameObject playButton;


    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if(roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 2 });
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomName name in roomNameList)
        {
            Destroy(name.gameObject);
        }

        roomNameList.Clear();

        foreach(RoomInfo room in list)
        {
            if (room.RemovedFromList)
            {
                return;
            }

            RoomName newRoom = Instantiate(roomNamePrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomNameList.Add(newRoom);
        }
    }
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);


    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }
    public void PlayButton()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
}
