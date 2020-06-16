using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour, IPunObservable
{
    [SerializeField]
    public int t1;
    [SerializeField]
    public int t2;

    public Text textT1, textT2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textT1.text = t1.ToString();
        textT2.text = t2.ToString();
    }

    public void GoalT1()
    {
        t1++;
        
    }

    public void GoalT2()
    {
        t2++;
        
    }

   

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(t1);
            stream.SendNext(t2);
        }
        else
        {
            t1 = (int)stream.ReceiveNext();
            t2 = (int)stream.ReceiveNext();
        }
    }
}
