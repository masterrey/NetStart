using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public GameObject prefabPlayer;
    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach(Player p in PhotonNetwork.PlayerList)
        {
            GameObject Player=Instantiate(prefabPlayer);
            Player.GetComponentInChildren<TextMesh>().text = p.NickName;
            
        }
        */
        Invoke("StartGame", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void StartGame()
    {
        GameObject Player = PhotonNetwork.Instantiate(prefabPlayer.name, Vector3.zero, Quaternion.identity, 0);
        //Player.GetComponentInChildren<TextMesh>().text = Player.GetComponent<PhotonView>().Owner.NickName;

    }
}
