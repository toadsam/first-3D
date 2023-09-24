using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate; //���ݼӵ�
    public int maxAmmo; 
    public int curAmmo;

    public BoxCollider meleeArea; //���ݹ���
    public TrailRenderer trailEffect; //����Ʈ
    public Transform bulletPos;
    public GameObject bullet;
    public Transform bulletCasePos;
    public GameObject bulletCase;


    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
       else if (type == Type.Range && curAmmo > 0) //���� �Ѿ��� 0���� ���� ��
        {
           // StopCoroutine("Shot");
           curAmmo--;
            StartCoroutine("Shot");
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;      

        yield return new WaitForSeconds(0.3f);       
        trailEffect.enabled = false;

    }

    IEnumerator Shot()
    {//1. �Ѿ˹߻�
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50; //���ν�Ƽ���� �־ �Ѿ��� �չ������� ������.

        yield return null;

        //2. ź�Ƕ������� �� ����
        GameObject intantCase = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);
        Rigidbody caseRigid = intantCase.GetComponent<Rigidbody>();
        Vector3 caseVec = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up * Random.Range(2, 3); //ź�Ǵ� �ѱ��� �ݴ�������� ������ �ϹǷ� -�� ���� �־� �����Ų��.
        caseRigid.AddForce(caseVec,ForceMode.Impulse);
        caseRigid.AddTorque(Vector3.up * 10, ForceMode.Impulse);
    }
    //Use() : ���η�ƾ -> Swing() :�����ƾ -> Use() ���η�ƾ���� �ٽ� ���ư���.
    //Use() ���η�ƾ +Swing() �ڷ�ƾ(co�� �����Ѵٴ� �ǹ�)  IEnumerator: �������Լ�Ŭ����
}
