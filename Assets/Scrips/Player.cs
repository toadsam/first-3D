using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] weapons;
    public bool[] hasWeapons;
    public GameObject[] grenades; //�����ϴ� ��ü�� ��Ʈ���ϱ� ���� �迭���� ����
    public int hasGrenades;

    public int ammo;
    public int coin;
    public int health;
    

    public int maxammo;
    public int maxcoin;
    public int maxhealth;
    public int maxhasGrenades;

    float hAxis;
    float vAxis;
    bool wDown;
    bool jDowm;
    bool iDown; //���� �������� �޼���
    bool sDown1;  //���� Ű�� �޴� �޼���
    bool sDown2;
    bool sDown3;

    bool isJump;
    bool isDodge;
    bool isSwap; // ��ü�ð��� ����� ���� �÷��� ���� �ۼ�

    Vector3 moveVec;
    Vector3 dodgeVec;
    Animator anim;
    Rigidbody rigid;

    GameObject nearObject;
    GameObject equipWeapon;
    int equipWeaponIndex = -1; //��ġ ��ȣ�� 0�̱� ������ 0���ν����ϸ� �ʱ� ���ǿ��� �ɸ�
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    


    // Update is called once per frame
    void Update()
    {

        GetInput();
        Move();
        Turn();      
        Jump();
        Dodge();
        Interation();
        Swap();
    }

    void GetInput()  //����Ű �޾ƿ��� �޼���
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDowm = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");


    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //�Ȱ��� ũ���� �������� ���ؼ� ��ֶ�������

        if(isDodge)  //�������¸� ������ �ٲ� �� �����ϱ� ���ؼ� ����
        {
            moveVec = dodgeVec;
        }

        if (isSwap)
        {
            moveVec = Vector3.zero; //���� ���⸦ �ٲٴ� ���̶�� �������� ���ߵ����Ѵ�.
        }
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //�ٿ���¸� �ӵ��� ���̱�

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec); //�÷��̾ ���� �������� ���⼳��
    }

    void Jump()
    {
        if(jDowm && moveVec == Vector3.zero && !isJump && !isDodge && !isSwap)  //������������, �������ְ� �������� �ƴϰ� ������ �ƴҶ�
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge() //�����°�
    {
        if (jDowm && moveVec != Vector3.zero && !isJump &&!isDodge && !isSwap)
        {
            dodgeVec = moveVec;
            speed *= 2;          
            anim.SetTrigger("doDodge"); 
            isDodge  = true;

            Invoke("DodgeOut", 0.4f);  //�ð����� ȣ���ϱ� ���ؼ��̴�.
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            anim.SetBool("isJump", false);
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)  //�ٸ� �ݶ��δ��� �����ϸ� ȣ��
    {
        if(other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.Ammo:
                    ammo += item.value;
                    if(ammo > maxammo)
                        ammo = maxammo;
                    break;
                case Item.Type.Coin:
                    coin += item.value;
                    if (coin > maxcoin)
                        coin = maxcoin;
                    break;
                case Item.Type.Heart:
                    health += item.value;
                    if (health > maxhealth)
                        health = maxhealth;
                    break;
                case Item.Type.Grenade:
                    grenades[hasGrenades].SetActive(true); 
                    hasGrenades += item.value;
                    if (hasGrenades > maxhasGrenades)
                        hasGrenades = maxhasGrenades;
                    break;                            
            }
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)  //�����ϰ� �ִ� �ݶ��δ��� �����Ӵ� �ѹ� �� ȣ��
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
      
    }
     void OnTriggerExit(Collider other) //������ �����ϸ� �Ͼ
    {
        if(other.tag == "Weapon")
            nearObject = null;
    }

    void Swap()
    {
        if (sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0))
            return;
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1))
            return;
        if (sDown3 && (!hasWeapons[2] || equipWeaponIndex == 2))
            return;
        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if(sDown2) weaponIndex = 1;
        if(sDown3) weaponIndex = 2;

        if((sDown1 || sDown2 || sDown3) && !isJump &&  !isDodge)
        {
            if(equipWeapon != null)  //ó���� ������ ���� ��� ó���ϱ�
                equipWeapon.SetActive(false);

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex];
            equipWeapon.SetActive(true);

            anim.SetTrigger("doSwap");
            isSwap = true;

            Invoke("SwapOut", 0.4f);
        }
    }
    void SwapOut()
    {      
        isSwap = false;
    }

    void Interation()
    {
        if(iDown && nearObject != null && !isJump && !isDodge)  //��ȣ�ۿ��� ������ �Ǿ��ٸ�
        {
            if(nearObject.tag == "Weapon")  //�ٵ� �����
            {
                Item item = nearObject.GetComponent<Item>();  
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;  //�� ���Ⱑ ���۵Ǿ��ٴ� ���� �˷���

                Destroy(nearObject);
            }
        }
    }

}
