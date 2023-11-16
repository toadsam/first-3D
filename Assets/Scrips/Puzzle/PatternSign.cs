
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
        var deleyTime = new WaitForSeconds(5f);  //���� �ڷ�ƾ�̱� ������ �������� ���̱� ���ؼ� ������ �ʱ�ȭ ���Ѽ� ����߽��ϴ�.
        while (true)
        {
            yield return deleyTime; // + ����
            _random = UnityEngine.Random.Range(0, 5);
            Debug.Log(_random);

            _puzzleObjects.SettingObject(_patterns[_random]);
            AnswerPattern();
        }
    }

    private void StartSetting()  //for������ �ѹ��� �ְ� ������ ����� �� ã�ڽ��ϴ�. �Ф�
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
