using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDowm;

    bool isJump;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;
    Animator anim;
    Rigidbody rigid;
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
    }

    void GetInput()  //방향키 받아오는 메서드
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDowm = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //똑같은 크기의 움직임을 위해서 노멀라이즈사용

        if(isDodge)  //닷지상태면 방향을 바꿀 수 없게하기 위해서 만듬
        {
            moveVec = dodgeVec;
        }

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime; //다운상태면 속도를 줄이기

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec); //플레이어가 가는 방향으로 방향설정
    }

    void Jump()
    {
        if(jDowm && moveVec == Vector3.zero && !isJump && !isDodge)  //점프를누르고, 가만이있고 점프중이 아니고 닫지가 아닐때
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge()
    {
        if (jDowm && moveVec != Vector3.zero && !isJump &&!isDodge)
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


}
