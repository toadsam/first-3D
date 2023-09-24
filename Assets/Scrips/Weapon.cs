using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate; //공격속도
    public int maxAmmo; 
    public int curAmmo;

    public BoxCollider meleeArea; //공격범위
    public TrailRenderer trailEffect; //이펙트
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
       else if (type == Type.Range && curAmmo > 0) //현재 총알이 0보다 많을 때
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
    {//1. 총알발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50; //벨로시티값을 주어서 총알의 앞방향으로 보낸다.

        yield return null;

        //2. 탄피떨어지는 것 구현
        GameObject intantCase = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);
        Rigidbody caseRigid = intantCase.GetComponent<Rigidbody>();
        Vector3 caseVec = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up * Random.Range(2, 3); //탄피는 총구의 반대방향으로 나가야 하므로 -의 값을 주어 실행시킨다.
        caseRigid.AddForce(caseVec,ForceMode.Impulse);
        caseRigid.AddTorque(Vector3.up * 10, ForceMode.Impulse);
    }
    //Use() : 메인루틴 -> Swing() :서브루틴 -> Use() 메인루틴으로 다시 돌아간다.
    //Use() 메인루틴 +Swing() 코루틴(co가 같이한다는 의미)  IEnumerator: 열거형함수클래스
}
