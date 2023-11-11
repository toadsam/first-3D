using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private Transform[] _ButtonPositoin = new Transform[4];
    private GameObject[] _Button = new GameObject[4];
    private List<int> _RandomPosList = new List<int>() { 0, 1, 2, 3 };
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
       for(int i = 0; i < _ButtonPositoin.Length; i++) 
        {
            _ButtonPositoin[i] = transform.GetChild(i).gameObject.transform;
            _Button[i] = transform.GetChild(_ButtonPositoin.Length -1 + i).gameObject;
        }
        for (int i = 0; i < _ButtonPositoin.Length; i++)
        {
            int rand = Random.Range(0, _RandomPosList.Count);
            _ButtonPositoin[_RandomPosList[rand]].transform.position = _Button[i].transform.position;
            _RandomPosList.RemoveAt(rand);
        }
    }

}
