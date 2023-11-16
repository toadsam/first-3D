
using System.Collections;
using UnityEngine;

public class PatternSign : MonoBehaviour
{
    private PuzzleObjects _puzzleObjects;

    [Header("patterns")]

    private int[] _pattern1 = {0, 0, 0,
                               0, 1, 0,
                               0, 0, 0 };
    private int[] _pattern2 ={ 1, 1, 2,
                               1, 1, 2,
                               1, 1, 2 };
    private int[] _pattern3 ={ 0, 1, 0,
                               1, 2, 1,
                               0, 1, 0 };
    private int[] _pattern4 ={ 2, 1, 2,
                               2, 1, 2,
                               1, 2, 2 };
    private int[] _pattern5 ={ 1, 1, 1,
                               1, 1, 1,
                               1, 1, 1 };


    private int[][] _patterns = new int[5][];

    private int _random;

    private void Awake()
    {
        _puzzleObjects = GetComponent<PuzzleObjects>();
        StartSetting();
    }
    private void Start()
    {
        StartCoroutine(PatternChange());
    }
    public IEnumerator PatternChange()  
    {
        var deleyTime = new WaitForSeconds(5f);  //무한 코루틴이기 때문에 가비지를 줄이기 위해서 변수를 초기화 시켜서 사용했습니다.
        while (true)
        {
            yield return deleyTime; // + 조건
            _random = UnityEngine.Random.Range(0, 5);
            Debug.Log(_random);

            _puzzleObjects.SettingObject(_patterns[_random]);
            AnswerPattern();
        }
    }

    private void StartSetting()  //for문으로 한번에 넣고 싶은데 방법을 못 찾겠습니다. ㅠㅠ
    {
        _patterns[0] = _pattern1;
        _patterns[1] = _pattern2;
        _patterns[2] = _pattern3;
        _patterns[3] = _pattern4;
        _patterns[4] = _pattern5;
    }

    public int[] AnswerPattern()
    {
        return _patterns[_random];
    }
}
