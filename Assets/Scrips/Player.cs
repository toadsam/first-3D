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

    void GetInput()  //����Ű �޾ƿ��� �޼���
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDowm = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //�Ȱ��� ũ���� �������� ���ؼ� ��ֶ�������

        if(isDodge)  //�������¸� ������ �ٲ� �� �����ϱ� ���ؼ� ����
        {
            moveVec = dodgeVec;
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
        if(jDowm && moveVec == Vector3.zero && !isJump && !isDodge)  //������������, �������ְ� �������� �ƴϰ� ������ �ƴҶ�
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


}
