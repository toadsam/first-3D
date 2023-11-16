using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance = null;
    public PuzzleObjects puzzleObjects;  //puzzleObjects�� �����ͼ� ������ �����ϰ� �ϰ�ʹ�.
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

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (CorrectAnswer())
        {
            Debug.Log("�¾Ҿ��");
        }
    }

    public bool CorrectAnswer()
    {
        bool isRight = puzzleObjects.QuestionPattern().SequenceEqual(patternSign.AnswerPattern());
        
        return isRight;
    }
}
