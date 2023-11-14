using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
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

    //private int[][] patterns =
    private int[] a = { 3,3,3,
                        3,3,3,
                        3,3,3 };
    private int[] b = {1,1,1,
                       0,0,0,
                       2,2,2};
    private int[] c = { 0,1,2,
                        0,1,2,
                        0,1,2};
    private int[] d = { 1,1,1,
                        1,1,1,
                        1,1,1};

    private void Awake()
    {
        
    }
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
                 PuzzleManager.instance._puzzleObjects.SettingObject(a);
                    Debug.Log("a");
                    break;
                case ButtonType.b:
                    PuzzleManager.instance._puzzleObjects.SettingObject(b);
                    Debug.Log("b");
                    break;
                case ButtonType.c:
                    PuzzleManager.instance._puzzleObjects.SettingObject(c);
                    Debug.Log("c");
                    break;
                case ButtonType.d:
                    PuzzleManager.instance._puzzleObjects.SettingObject(d);
                    Debug.Log("d");
                    break;

            }
        }
    }
}
