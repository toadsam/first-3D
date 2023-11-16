using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    [Header("Management target")]
    public static PuzzleManager instance = null;
    public PuzzleObjects puzzleObjects;  
    public PatternSign patternSign;

    public bool isClear;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
          DontDestroyOnLoad(this.gameObject);
        }
        else
        {      
            Destroy(this.gameObject);
        }
        puzzleObjects = transform.GetChild(0).gameObject.GetComponent<PuzzleObjects>();
        patternSign = transform.GetChild(2).gameObject.GetComponent<PatternSign>();

    }
    private void Update()
    {
        if (CorrectAnswer())
        {
            Debug.Log("�¾Ҿ��"); //���Ŀ� ���ٿ���
        }
    }

    public bool CorrectAnswer() //���� ���ϰ� Ǯ���ִ� ������ �´��� Ȯ���� �� �� ���� ����Ѵ�.
    {
        bool isRight = puzzleObjects.QuestionPattern().SequenceEqual(patternSign.AnswerPattern());
        
        return isRight;
    }
}
