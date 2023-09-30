using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyFireBall : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.Instance.player.transform;
        nav = GetComponent<NavMeshAgent>();
        ps = GetComponent<ParticleSystem>();
        Invoke("Destroy", 4);
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            Player.health -= 2;
            Debug.Log("�ҷθ���ü�� " + Player.health);
            Destroy(this.gameObject);
        }
    }

}
