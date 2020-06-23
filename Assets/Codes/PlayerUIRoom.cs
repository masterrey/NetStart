using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIRoom : MonoBehaviour
{
    public PhotonView pview;
    public Text text;
    public Toggle team;
    public Toggle ready;
    public bool bready = false;
    public bool houseTeam = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!pview.IsMine)
        {
            team.interactable = false;
            ready.interactable = false;
        }
        
        text.text = pview.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TeamChange()
    {
        houseTeam = team.isOn;
        pview.RPC("StatusChanged", RpcTarget.OthersBuffered, bready, houseTeam);
    }

    public void ReadyChange()
    {
        bready = ready.isOn;
        pview.RPC("StatusChanged", RpcTarget.OthersBuffered, bready, houseTeam);
    }
    [PunRPC]
    void StatusChanged(bool mybready,bool myhouseTeam)
    {
        bready = mybready;
        houseTeam = myhouseTeam;

        team.isOn = houseTeam;
        ready.isOn = bready;
    }
}
