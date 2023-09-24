using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Type
    {
        Ammo,
        Coin,
        Grenade,
        Heart,
        Weapon
    }

    public Type type;
    public int value;

    Rigidbody rigid;
    SphereCollider sphereCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        
    }

    private void Update()
    {
        transform.Rotate(Vector3 .up * Time.deltaTime *20);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            rigid.isKinematic = true;
            sphereCollider.enabled = false;

        }
        
    }
}
