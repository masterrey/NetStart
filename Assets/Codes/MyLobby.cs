using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using System;
using System.Linq;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public InputField namefield;
    public GameObject roomPanel;
    public GameObject gameRoomContent;
    public List<PlayerUIRoom> playerUIRooms;
    public PhotonView pview;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckAllReady", 1, 1);
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
            print("founded");
            if (!playerUIRooms.Contains(ob.GetComponent<PlayerUIRoom>()))
            {
                playerUIRooms.Add(ob.GetComponent<PlayerUIRoom>());
            }
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

    void CheckAllReady()
    {
        bool allready = true;
        if (playerUIRooms.Count >1)
        {
            allready = playerUIRooms.All(x => x.ready);//Soluçao LucasTeles

            if (allready)
            {
               
                pview.RPC("BroadcastLoadScene", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    void BroadcastLoadScene()
    {
        PhotonNetwork.LoadLevel("Arena");
    }

}
