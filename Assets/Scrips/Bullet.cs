using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject,3);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }


}
