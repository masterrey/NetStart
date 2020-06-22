using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using System;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public InputField namefield;
    public GameObject roomPanel;
    public GameObject gameRoomContent;
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
        if (string.IsNullOrWhiteSpace(field))
        {
            field= "Fulano " + Guid.NewGuid();
        }
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
        GameObject ob = PhotonNetwork.Instantiate("PlayerUIRoom", Vector3.zero, Quaternion.identity);
        ob.transform.SetParent(gameRoomContent.transform);
        ob.GetComponent<RectTransform>().localPosition = new Vector3(100,-20,0);


        Invoke("FixName", 2);

        print("Conectado na room: "+ PhotonNetwork.CurrentRoom.Name);

       // PhotonNetwork.LoadLevel("Arena");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("other entered");
        Invoke("FixName", 2);
       
    }

    void FixName()
    {
        print("searching "+ gameRoomContent.name);
        GameObject[] obs = GameObject.FindGameObjectsWithTag("UIPlayer");
        foreach(GameObject ob in obs)
        {
            ob.transform.SetParent(gameRoomContent.transform);
            ob.GetComponent<RectTransform>().localPosition = new Vector3(100, -20, 0);
            print("founded");
        }

    }
    

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Não tem nenhuma sala, criando uma...");
        string name = "Sala " + Guid.NewGuid();
        RoomOptions op = new RoomOptions();
        op.MaxPlayers = 8;
        PhotonNetwork.CreateRoom(name, op, null);
        print("NomedaSala: " + name);
    }

}
