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
            Debug.Log("맞았어요"); //이후에 없앨예정
        }
    }

    public bool CorrectAnswer() //정답 패턴과 풀고있는 패턴이 맞는지 확인한 후 불 값을 출력한다.
    {
        bool isRight = puzzleObjects.QuestionPattern().SequenceEqual(patternSign.AnswerPattern());
        
        return isRight;
    }
}
