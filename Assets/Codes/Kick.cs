using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public PhotonView pview;
    Rigidbody ball;
    PhotonView pball;
    private void Start()
    {
        if (!pview.IsMine)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (ball && Input.GetButtonDown("Fire1"))
        {
            ball.AddForce(transform.forward*10 + Vector3.up*5, ForceMode.Impulse);
        }
        if (ball && Input.GetButtonDown("Fire2"))
        {
            ball.AddForce(transform.forward * 5, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {

            ball = other.GetComponent<Rigidbody>();
            pball = other.GetComponent<PhotonView>();
            pball.RequestOwnership();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        ball = null;
    }
}
