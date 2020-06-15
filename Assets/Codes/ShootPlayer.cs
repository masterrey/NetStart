using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public ParticleSystem shooter;
    public PhotonView pview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pview.IsMine)
        {
           
            if (Input.GetButtonDown("Fire1"))
            {
                //WeaponFire();
                pview.RPC("WeaponFire", RpcTarget.All);
                //pview.RPC(nameof(WeaponFire), RpcTarget.All);
            }
        }
    }
    [PunRPC]
    void WeaponFire()
    {
        shooter.Emit(1);
    }
}
