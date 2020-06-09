using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCam : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
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
            transform.LookAt(target.transform);
            transform.position = target.transform.position + offset;
        }
    }
}
