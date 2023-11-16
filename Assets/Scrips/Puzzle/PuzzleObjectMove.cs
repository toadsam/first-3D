
using System.Collections;
using UnityEngine;

public class PuzzleObjectMove : Thorn
{
    [Header("MoveBool")]
    private bool _isRotate;
    private bool _isMove;
    private int _isResolve;

    private int[] _movePattern = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
   
    private void Start() //����� ���ؼ� �� ģ���� ������ ��ġ�� �����̵��ϱ� ������ ���ټ��� ����.....�Ф�
    {

    }

    private void Update()
    {

        ClearMove();
    }

    public IEnumerator MoveStart() //�ѹ��� ���� ��ų �� �ִ� �ڷ�ƾ ����� ����
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

    private void OnCollisionEnter(Collision collision)   //�̰� �÷��̾���null�� �ѹ� �˾ƺ���
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
