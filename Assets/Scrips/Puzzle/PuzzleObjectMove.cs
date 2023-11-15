using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PuzzleObjectMove : Thorn
{
    private bool _isRotate;
    private bool _isMove;
    private int[] movePattern = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //���� �Ŵ����� �Ұ��� �����Ѵ�. ����
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleManager.instance.CorrectAnswer())
        {
            ThornMove();
        }
        if (_isRotate)
        {
            Rotate();
        }
    }

    public IEnumerator MoveStart()
    {
        _isRotate = true;
        yield return new WaitForSeconds(1f); // + ����
        PuzzleManager.instance._puzzleObjects.SettingObject(movePattern);
        yield return new WaitForSeconds(5f); // + ����
        _isRotate = false;
    }

    private void Rotate()
    {
        //  transform.rotation
        transform.Rotate(Vector3.up * Time.deltaTime * 500, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {  //�ϴ� üũ�� �Ǿ��Ѵ�.
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MoveStart());
        }
    }

}
