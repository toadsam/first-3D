using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType  //���⼭ �ʿ��� �������� �߰��ϸ� �˴ϴ� �ϴ��� ������ ������Ʈ�� ���� ������ ���ĺ����� �ο����ϴ�.
{
    a,
    b,
    c,
    d,
    e,
    f
}
public class Button : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_buttonType)
            {
                case ButtonType.a:
                    Debug.Log("a");
                    break;
                case ButtonType.b:
                    Debug.Log("b");
                    break;
                case ButtonType.c:
                    Debug.Log("c");
                    break;
                case ButtonType.d:
                    Debug.Log("d");
                    break;

            }
        }
    }
}
