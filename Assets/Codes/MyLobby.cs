using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

using static Photon.Pun.PhotonNetwork;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public InputField namefield;
    public GameObject roomPanel;

    public void PlayGame()
    {
        var field = namefield.text;
        LocalPlayer.NickName = field;
        ConnectUsingSettings();
    }

    public void JoinRoom() => JoinRandomRoom();

    public override void OnConnectedToMaster() => roomPanel.SetActive(true);

    public override void OnJoinedRoom()
    {
        print($"Conectado na room: {CurrentRoom.Name}");
        LoadLevel("Arena");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Não tem nenhuma sala, criando uma...");
        var roomName = $"Sala_{Guid.NewGuid()}";
        
        var op = new RoomOptions
        {
            MaxPlayers = 8
        };
        
        CreateRoom(roomName, op);
        print($"NomedaSala: {roomName}");
    }

}
