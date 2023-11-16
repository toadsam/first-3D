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
    private int _isResolve;
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
            if (_isResolve == 0)
            {
                StartCoroutine(MoveStart());
                _isResolve = 1;
            }
        }
        if (_isRotate)
        {
            Rotate();
        }
        if (_isMove)
        {
            ThornMove();
        }
    }

    public IEnumerator MoveStart() //�ѹ��� ���� ��ų �� �ִ� �ڷ�ƾ ����� ����
    {
        _isRotate = true;
        yield return new WaitForSeconds(1f); // + ����
        PuzzleManager.instance.puzzleObjects.SettingObject(movePattern);
        yield return new WaitForSeconds(5f); // + ����
        _isRotate = false;
        _isMove = true;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 500, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("adw");
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
