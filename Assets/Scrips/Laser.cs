using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Player player;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            // playerConditions.health.curValue -= 1f;
            //  Player.health -= 2;
            //  Debug.Log("ºÒ·Î¸ÂÀºÃ¼·Â " + Player.health);
            Debug.Log("나나나난");
        }
    }
}
