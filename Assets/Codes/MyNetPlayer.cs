using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNetPlayer : MonoBehaviour
{
    public TextMesh myname;
    public PhotonView pview;
    public Rigidbody rdb;
    Vector3 myinput;
    public Animator anim;
    public SkinnedMeshRenderer[] rends;
    float velocityMul=5;
    // Start is called before the first frame update
    void Start()
    {
        myname.text = pview.Owner.NickName;
        if (pview.InstantiationId % 2 == 0)
        {

            foreach(SkinnedMeshRenderer rend in rends)
            rend.material.SetColor("_Color", Color.red);
        }

        if (pview.IsMine)
        {
            Camera.main.GetComponent<MyCam>().SetTarget(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myname.transform.forward=(myname.transform.position-Camera.main.transform.position); //billboard

        if (pview.IsMine)
        {
            //transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            myinput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
           
        }
      
    }
    private void FixedUpdate()
    {



        Vector3 localvelocity = transform.InverseTransformDirection(rdb.velocity);
        anim.SetFloat("Velocity", localvelocity.z);
        anim.SetFloat("SideVel", localvelocity.x);

        if (pview.IsMine)
        {
            rdb.velocity = myinput* velocityMul;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit, 100))
            {
                Vector3 myhit = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(myhit);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(Slowmotion());
    }

    IEnumerator Slowmotion()
    {

        velocityMul = 1;
        yield return new WaitForSeconds(5);
        velocityMul = 5;

    }
}
