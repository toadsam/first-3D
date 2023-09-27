using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            Player.health -= 5;
            Debug.Log("불" + Player.health);
        }
        //Debug.Log("파티클 충돌");

    }
}
