using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    // public GameObject prefabPlayer;

    void Start()
    {
        // foreach (var p in PhotonNetwork.PlayerList)
        // {
        //     var Player = Instantiate(prefabPlayer);
        //     Player.GetComponentInChildren<TextMesh>().text = p.NickName;
        // }

        Invoke(nameof(StartGame), 10);
    }

    void StartGame()
    {
        var player = PhotonNetwork.Instantiate("MyPlayer", Vector3.zero, Quaternion.identity, 0);
        player.GetComponentInChildren<TextMesh>().text = player.GetComponent<PhotonView>().Owner.NickName;
    }
}