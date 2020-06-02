using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public InputField namefield;
    public GameObject roomPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        string field = namefield.text;

        PhotonNetwork.LocalPlayer.NickName = field;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {

        roomPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        
        print("Conectado na room: "+ PhotonNetwork.CurrentRoom.Name);

        PhotonNetwork.LoadLevel("Arena");
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Não tem nenhuma sala, criando uma...");
        string name = "Sala" + Random.Range(0, 1000);
        RoomOptions op = new RoomOptions();
        op.MaxPlayers = 8;
        PhotonNetwork.CreateRoom(name, op, null);
        print("NomedaSala: " + name);
    }

}
