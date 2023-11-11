using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjects : MonoBehaviour
{
    private GameObject _gameObject0;
    private GameObject _gameObject1;
    private GameObject _gameObject2;
    private GameObject _gameObject3;
    private GameObject _gameObject4;
    private GameObject _gameObject5;
    private GameObject _gameObject6;
    private GameObject _gameObject7;
    private GameObject _gameObject8;

    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSetting()
    {
        _gameObject0 = transform.GetChild(0).gameObject;
        _gameObject1 = transform.GetChild(1).gameObject;
        _gameObject2 = transform.GetChild(2).gameObject;
        _gameObject3 = transform.GetChild(3).gameObject;
        _gameObject4 = transform.GetChild(4).gameObject;
        _gameObject5 = transform.GetChild(5).gameObject;
        _gameObject6 = transform.GetChild(6).gameObject;
        _gameObject7 = transform.GetChild(7).gameObject;
        _gameObject8 = transform.GetChild(8).gameObject;
    }
}
