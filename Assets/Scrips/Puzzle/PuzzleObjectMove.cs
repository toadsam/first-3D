
using System.Collections;
using UnityEngine;

public class PuzzleObjectMove : Thorn
{
    [Header("MoveBool")]
    private bool _isRotate;
    private bool _isMove;
    private int _isResolve;

    private int[] _movePattern = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
   
    private void Start() //상속을 통해서 이 친구가 없으면 위치가 순간이동하기 때문에 없앨수가 없다.....ㅠㅠ
    {

    }

    private void Update()
    {

        ClearMove();
    }

    public IEnumerator MoveStart() //한번만 실행 시킬 수 있는 코루틴 만들어 보기
    {
        _isRotate = true;
        yield return new WaitForSeconds(1f); 
        PuzzleManager.instance.puzzleObjects.SettingObject(_movePattern);
        yield return new WaitForSeconds(5f); 
        _isRotate = false;
        _isMove = true;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 500, Space.World);
    }

    private void OnCollisionEnter(Collision collision)   //이거 플레이어의null값 한번 알아보기
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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

    private void ClearMove()
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

}
