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
    //퍼즐 매니저의 불값이 결정한다. ㅎㅎ
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

    public IEnumerator MoveStart() //한번만 실행 시킬 수 있는 코루틴 만들어 보기
    {
        _isRotate = true;
        yield return new WaitForSeconds(1f); // + 조건
        PuzzleManager.instance.puzzleObjects.SettingObject(movePattern);
        yield return new WaitForSeconds(5f); // + 조건
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
