using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance = null;
    public PuzzleObjects puzzleObjects;  //puzzleObjects를 가져와서 관리를 용이하게 하고싶다.
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
            Debug.Log("맞았어요");
        }
    }

    public bool CorrectAnswer()
    {
        bool isRight = puzzleObjects.QuestionPattern().SequenceEqual(patternSign.AnswerPattern());
        
        return isRight;
    }
}
