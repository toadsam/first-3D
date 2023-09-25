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
    public GameObject[] grenades; //공전하는 물체를 컨트롤하기 위해 배열변수 생성
    public int hasGrenades;
    public Camera followCamera;

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
    bool fDown; //공격키
    bool rDown; // 장전키
    bool iDown; //무기 장착관련 메서드
    bool sDown1;  //무기 키를 받는 메서드
    bool sDown2;
    bool sDown3;

    bool isJump;
    bool isDodge;
    bool isSwap; // 교체시간을 만들기 위한 플래그 로직 작성
    bool isReload; //장전시간을 위해서 생성
    bool isFireReady = true;//공격이 가능한지 여부알기
    bool isBorder; //벽 충돌을 인지하기 위한 변수생성

    Vector3 moveVec;
    Vector3 dodgeVec;
    Animator anim;
    Rigidbody rigid;

    GameObject nearObject;
    Weapon equipWeapon;
    int equipWeaponIndex = -1; //망치 번호가 0이기 때문에 0으로시작하면 초기 조건에서 걸림
    float fireDeley;// 공격대기시간

    private RotateToMouse rotateToMouse; // 마우스 이동으로 카메라 회전
    // Start is called before the first frame update
    private void Awake()
    {
        rotateToMouse = GetComponent<RotateToMouse>();  //카메라 속성가져오고
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
        Attack();
        Reload();
        Dodge();
        Interation();
        Swap();
        UpdateRotate();
    }

    void GetInput()  //방향키 받아오는 메서드
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDowm = Input.GetButtonDown("Jump");
        fDown = Input.GetButton("Fire1"); //다운으로하면 한번씩만 실행되기 때문에 그냥 버튼으로해서 계속해도 작동되도록함.
        rDown = Input.GetButtonDown("Reload");
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");


    }

    void Move()
    {
        Vector3 a = transform.right * hAxis;
        Vector3 b = transform.forward * vAxis;
        moveVec = (a + b).normalized * 2;
        rigid.MovePosition(transform.position +  moveVec * Time.deltaTime);
        //moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //똑같은 크기의 움직임을 위해서 노멀라이즈사용
        //moveVec = (hAxis + vAxis).
        if (isDodge)  //닷지상태면 방향을 바꿀 수 없게하기 위해서 만듬
        {
            moveVec = dodgeVec;
        }

        if (isSwap  || isReload  || !isFireReady)
        {
            moveVec = Vector3.zero; //만약 무기를 바꾸는 중이라면 움직임을 멈추도록한다.
        }

        if(!isBorder) //이렇게 조건문을 설정하므로써 회전을 할 수 있지만 움직임은 막을 수 있다.
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //다운상태면 속도를 줄이기

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
       // transform.LookAt(transform.position + moveVec); //플레이어가 가는 방향으로 방향설정

        //마우스에 의한 회전
        if (fDown)
        {
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit; //정보를 저장할 변수 추가
            if (Physics.Raycast(ray, out rayHit, 100))  //out: return처럼 반환값을 주어진 변수에 저장하는 키워드
            {
                Vector3 nextVec = rayHit.point - transform.position; //상대적 위치 거리 구하기
                nextVec.y = 0f; //레이케스트히트의 높이는 무시하도록 y축 값을 0으로 초기화시킨다.
                transform.LookAt(transform.position + nextVec); //마우스 클릭한부분 쳐다보기
            }
        }
    }

    void Jump()
    {
        if(jDowm && moveVec == Vector3.zero && !isJump && !isDodge && !isSwap)  //점프를누르고, 가만이있고 점프중이 아니고 닫지가 아닐때
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Attack()
    {
        if (equipWeapon == null)
            return;

        fireDeley += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDeley;  //공격할 수 있는 조건이 충족된다면

        if(fDown && isFireReady && !isDodge && !isSwap)
        {
            equipWeapon.Use();
            anim.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "doSwing" : "doShot") ;
            fireDeley = 0;
        }
    }
    
    void Reload()
    {
        if (equipWeapon == null)
            return;
        if (equipWeapon.type == Weapon.Type.Melee)
            return;
        if (ammo == 0)
            return;
        if(rDown && !isJump && !isDodge && !isSwap && isFireReady)
        {
            anim.SetTrigger("doReload");
            isReload = true;

            Invoke("ReloadOut", 3f);
        }

    }

    void ReloadOut()
    {
        int reAmmo = ammo < equipWeapon.maxAmmo ? ammo : equipWeapon.maxAmmo; //가지고있는 총알이 최대 총알보다 많은지 적은지
        equipWeapon.curAmmo = reAmmo;
        ammo -= reAmmo;
        isReload = false;
        //총알이 남아있는상태에서 충전을해도 그냥 최대 총량만큼 충전이되는 문제가 발생함.reAmmo에서 현재의 탄알을 뺀 것을 더해야할듯
    }

    void Dodge() //구르는거
    {
        if (jDowm && moveVec != Vector3.zero && !isJump &&!isDodge && !isSwap)
        {
            dodgeVec = moveVec;
            speed *= 2;          
            anim.SetTrigger("doDodge"); 
            isDodge  = true;

            Invoke("DodgeOut", 0.4f);  //시간차로 호출하기 위해서이다.
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

    private void OnTriggerEnter(Collider other)  //다른 콜라인더가 반응하면 호출
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

    void OnTriggerStay(Collider other)  //접촉하고 있는 콜라인더에 프레임당 한번 씩 호출
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
      
    }
     void OnTriggerExit(Collider other) //접촉을 중지하면 일어남
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
            if(equipWeapon != null)  //처음에 아이템 없는 경우 처리하기
                equipWeapon.gameObject.SetActive(false);

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);

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
        if(iDown && nearObject != null && !isJump && !isDodge)  //상호작용의 조건이 되었다면
        {
            if(nearObject.tag == "Weapon")  //근데 무기면
            {
                Item item = nearObject.GetComponent<Item>();  
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;  //그 무기가 장작되었다는 것을 알려줌

                Destroy(nearObject);
            }
        }
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall")); // 레이를 쏘아 닿는 오브젝트를 감지한다.
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero; // 물리회전 속로를 컨트롤 할 수 있다. 도는 이유가 탄피랑 플레이어랑 출동해서 그렇다. 
    }

    private void FixedUpdate()
    {
        FreezeRotation();
        StopToWall();
    }
    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }
}
