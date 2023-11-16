
using UnityEngine;

public enum ButtonType  //���⼭ �ʿ��� �������� �߰��ϸ� �˴ϴ� �ϴ��� ������ ������Ʈ�� ���� ������ ���ĺ����� �ο����ϴ�.
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

    private int[] _reset =  {0,0,0,
                             0,0,0,
                             0,0,0};
    private void OnTriggerEnter(Collider other)
    {
        int[] curPattern = PuzzleManager.instance.puzzleObjects.QuestionPattern();
        if (other.CompareTag("Player"))
        {
            switch (_buttonType)
            {
                case ButtonType.reset:
                    PuzzleManager.instance.puzzleObjects.SettingObject(_reset);
                    Debug.Log("_reset");
                    break;
                case ButtonType.widthTop:
                    ThreeChangePuzzle(curPattern, 0, 1, 2);      
                 PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthTop");
                    break;
                case ButtonType.widthMiddle:
                    ThreeChangePuzzle(curPattern, 3, 4, 5);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthMiddle");
                    break;
                case ButtonType.widthBottom:
                    ThreeChangePuzzle(curPattern, 6, 7, 8);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("widthBottom");
                    break;
                case ButtonType.lengthRight:
                    ThreeChangePuzzle(curPattern, 0, 3, 6);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthRight");
                    break;
                case ButtonType.lengthMiddle:
                    ThreeChangePuzzle(curPattern, 1, 4, 7);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthMiddle");
                    break;
                case ButtonType.lengthLeft:
                    ThreeChangePuzzle(curPattern, 2, 5, 8);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    Debug.Log("lengthLeft");
                    break;

            }
        }
    }

    private void ThreeChangePuzzle(int[]cur,int one,int two,int three )  //�׳� ���ϰ� �Ϲ� �޼���� ������
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
