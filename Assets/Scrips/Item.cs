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
    private void Start()
    {
        //rigid.AddExplosionForce(10, this.transform.up, 10);
      //  rigid.AddForce(transform.up * 30, ForceMode.Impulse);
    }

    private void Update()
    {
        transform.Rotate(Vector3 .up * Time.deltaTime *20);
       // rigid.AddExplosionForce(10, this.transform.up, 10);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            rigid.isKinematic = true;
            sphereCollider.enabled = false;
            Invoke("Destroy", 4);
            
        }
        
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
