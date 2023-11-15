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
        yield return new WaitForSeconds(1f); // + 조건
        PuzzleManager.instance._puzzleObjects.SettingObject(movePattern);
        yield return new WaitForSeconds(5f); // + 조건
        _isRotate = false;
    }

    private void Rotate()
    {
        //  transform.rotation
        transform.Rotate(Vector3.up * Time.deltaTime * 500, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {  //일단 체크가 되야한다.
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MoveStart());
        }
    }

}
