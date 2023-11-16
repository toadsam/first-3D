using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PatternSign : MonoBehaviour
{
    private PuzzleObjects puzzleObjects;

    int[] pattern1 = { 0, 0, 0,
                       0, 1, 0,
                       0, 0, 0 };
    int[] pattern2 ={ 1, 1, 2,
                      1, 1, 2,
                      1, 1, 2 };
    int[] pattern3 ={ 0, 1, 0,
                      1, 2, 1,
                      0, 1, 0 };
    int[] pattern4 ={ 2, 1, 2,
                      2, 1, 2,
                      1, 2, 2 };
    int[] pattern5 ={ 1, 1, 1,
                      1, 1, 1,
                      1, 1, 1 };


    int[][] patterns = new int[5][];

    bool isCheak;
    private int _random;
    // Start is called before the first frame update

    private void Awake()
    {
        puzzleObjects = GetComponent<PuzzleObjects>();
        StartSetting();
    }
    void Start()
    {
        //puzzleObjects.SettingObject(patterns[0]);
        StartCoroutine(PatternChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PatternChange()  
    {
        var deleyTime = new WaitForSeconds(5f);
        while (true)
        {
            yield return deleyTime; // + Á¶°Ç
            _random = UnityEngine.Random.Range(0, 5);
            Debug.Log(_random);

            puzzleObjects.SettingObject(patterns[_random]);
            AnswerPattern();
        }
    }

    private void StartSetting()
    {
        patterns[0] = pattern1;
        patterns[1] = pattern2;
        patterns[2] = pattern3;
        patterns[3] = pattern4;
        patterns[4] = pattern5;
    }

    public int[] AnswerPattern()
    {
        return patterns[_random];
    }
}
