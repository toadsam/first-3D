using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
{
    reset,
    widthTop,
    widthMiddle,
    widthBottom,
    lengthRight,
    lengthMiddle,
    lengthLeft
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

    private int[] _reset =  {0,0,0,
                             0,0,0,
                             0,0,0};
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
        int[] curPattern = PuzzleManager.instance._puzzleObjects.QuestionPattern();
        if (other.CompareTag("Player"))
        {
            switch (_buttonType)
            {
                case ButtonType.reset:
                    PuzzleManager.instance._puzzleObjects.SettingObject(_reset);
                    Debug.Log("_reset");
                    break;
                case ButtonType.widthTop:
                    ThreeChangePuzzle(curPattern, 0, 1, 2);      
                 PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthTop");
                    break;
                case ButtonType.widthMiddle:
                    ThreeChangePuzzle(curPattern, 3, 4, 5);
                    PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthMiddle");
                    break;
                case ButtonType.widthBottom:
                    ThreeChangePuzzle(curPattern, 6, 7, 8);
                    PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthBottom");
                    break;
                case ButtonType.lengthRight:
                    ThreeChangePuzzle(curPattern, 0, 3, 6);
                    PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthRight");
                    break;
                case ButtonType.lengthMiddle:
                    ThreeChangePuzzle(curPattern, 1, 4, 7);
                    PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthMiddle");
                    break;
                case ButtonType.lengthLeft:
                    ThreeChangePuzzle(curPattern, 2, 5, 8);
                    PuzzleManager.instance._puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthLeft");
                    break;

            }
        }
    }

    private void ThreeChangePuzzle(int[]cur,int one,int two,int three )
    {
        cur[one] += 1;
        cur[two] += 1;
        cur[three] += 1;
        if (cur[one] == 3)
            cur[one] = 0;
        if (cur[two] == 3)
            cur[two] = 0;
        if (cur[three] == 3)
            cur[three] = 0;

    }
}
