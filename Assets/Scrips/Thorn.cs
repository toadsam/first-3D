using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    [Header("Object Pos")]
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private Transform _ThornPos;

    [Header("Object Time")]
    [SerializeField]public float _pos1Time;
    [SerializeField] public float _pos2Time;
    // Start is called before the first frame update
    private int count;
    void Start()
    {
        //_pos1 = transform.GetChild(0).transform;
        //_pos2 = transform.GetChild(1).transform;
        //_ThornPos = transform.GetChild(2).transform;
        _ThornPos.position = _pos2.position;
    }

    // Update is called once per frame
    void Update()
    {
        ThornMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("가시에 닿았습니다");
        }
    }

     public void ThornMove()
    {
        if (count == 0)
        {
            _ThornPos.position = Vector3.MoveTowards(_ThornPos.position, _pos1.position, _pos1Time);//0.15f_pos1Time
            if (_ThornPos.position == _pos1.position)
            {
                count++;
            }

        }
        if (count == 1)
        {
            _ThornPos.position = Vector3.MoveTowards(_ThornPos.position, _pos2.position, _pos2Time);// 0.01f_pos2Time
            if (_ThornPos.position == _pos2.position)
            {
                count--;
            }

        }
    }

    public void PuzzleMove() { 

    }
}
