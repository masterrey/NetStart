using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    public Rigidbody rdb;
    public PhotonView pview;
    // Start is called before the first frame update
    void Start()
    {
        pview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Vector3 direction = other.transform.forward;
        pview.RPC("BallForce", RpcTarget.All, direction);
    }

    [PunRPC]
    void BallForce(Vector3 dir)
    {
        rdb.AddForce(dir* 10, ForceMode.Impulse);
    }
}
