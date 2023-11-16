
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private Transform[] _ButtonPositoin = new Transform[7];
    private GameObject[] _Button = new GameObject[7];
    private List<int> _RandomPosList = new List<int>() { 0, 1, 2, 3, 4, 5, 6};
    
    private void Start()
    {
        StartSetting();
    }

    private void StartSetting()
    {
       for(int i = 0; i < _ButtonPositoin.Length; i++) 
        {
            if (transform.GetChild(i).gameObject == null && transform.GetChild(_ButtonPositoin.Length + i).gameObject == null)  //����ó�� �غôµ� �̷������� �ϴ°� �´���...�Ф�
                return;
                        
            _ButtonPositoin[i] = transform.GetChild(i).gameObject.transform;
            _Button[i] = transform.GetChild(_ButtonPositoin.Length + i).gameObject;
        }
        for (int i = 0; i < _ButtonPositoin.Length; i++)
        {
            int rand = Random.Range(0, _RandomPosList.Count);
            _Button[i].transform.position  = _ButtonPositoin[_RandomPosList[rand]].transform.position;
            _RandomPosList.RemoveAt(rand);
        }
    }

}
