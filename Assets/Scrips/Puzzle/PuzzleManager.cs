using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance = null;
    // Start is called before the first frame update
    public PuzzleObjects _puzzleObjects;  //_puzzleObjects를 가져와서 관리를 용이하게 하고싶다.
    public PatternSign patternSign;


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
        _puzzleObjects = transform.GetChild(0).gameObject.GetComponent<PuzzleObjects>();
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

    private bool CorrectAnswer()
    {
        bool isRight = _puzzleObjects.QuestionPattern().SequenceEqual(patternSign.AnswerPattern());
        
        return isRight;
    }
}
