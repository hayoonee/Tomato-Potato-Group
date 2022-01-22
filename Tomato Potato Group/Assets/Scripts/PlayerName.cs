using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;


public class PlayerName : MonoBehaviour
{
    [SerializeField] private Text _playerName;


    [SerializeField] private Player _player;

    public void SetPlayerInfo(Player player)
    {
        _player = player;
        _playerName.text = player.NickName;
    }

}
