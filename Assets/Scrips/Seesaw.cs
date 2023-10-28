using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    Transform SeesawRotaion_x;
    Rigidbody rigidbody;
    public Transform Addforce1;
    public Transform Addforce2;
    // Start is called before the first frame update
    void Start()
    {
        SeesawRotaion_x = GetComponent<Transform>();
        rigidbody  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SeesawRotaion_x.rotation.x);
        if (SeesawRotaion_x.rotation.x > 0)
        {
            rigidbody.AddForce(Addforce1.up *10 , ForceMode.Force);
        }
        else if(SeesawRotaion_x.rotation.x < 0)
        {
            rigidbody.AddForce(Addforce2.up * 10, ForceMode.Force);
        }
    }
}
