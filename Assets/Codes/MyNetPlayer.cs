using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetPlayer : MonoBehaviour
{
    public PhotonView pview;

    void Update()
    {
        if (pview.IsMine)
            transform.Translate(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"),
                0);
    }
}