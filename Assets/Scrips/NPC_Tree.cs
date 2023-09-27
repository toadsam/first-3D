using System.Collections;
using UnityEngine;

public class NPC_Tree : MonoBehaviour
{
    public int health;
    private MeshRenderer[] meshRenderers;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderers = GetComponents<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            health -= weapon.damage;
            Debug.Log("몬스터 체력 : " + health);
        }

        //if (other.tag == "Bullet")
        //{
        //    Bullet bullet = other.GetComponent<Bullet>();
        //    health -= bullet.damage;
        //    Debug.Log("몬스터 체력 : " + health);
        //}
        if (health <= 0)
        {

            //Invoke("Respwan",4);
           // Die();
          //  DropItem();
          Destroy(gameObject);

        }
        StartCoroutine(DamageFlash());
    }

    IEnumerator DamageFlash() //깜빡이는 것임.
    {
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = new Color(1.0f, 0.6f, 0.6f);

        yield return new WaitForSeconds(0.4f);
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = Color.white;
    }
}
