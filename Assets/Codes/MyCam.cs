using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCam : MonoBehaviour
{
    public GameObject target;
    public GameObject targetBall;
    public Vector3 offset;
    public float ajust=4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTarget(GameObject tgt)
    {
        target = tgt;
    }


  
    void LateUpdate()
    {
        if (target)
        {
            
           Vector3 dir = (target.transform.position - targetBall.transform.position)/2;

            Vector3 median = (target.transform.position + targetBall.transform.position) / 2;

            transform.LookAt(median);
            transform.position = median + offset * Mathf.Clamp((dir.magnitude*0.2f),1,100);
        }
    }
}
