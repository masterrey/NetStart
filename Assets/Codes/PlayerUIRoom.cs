﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIRoom : MonoBehaviour
{
    public PhotonView pview;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = pview.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
