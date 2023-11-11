using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Lebu2 : MonoBehaviour
{
    private GameObject _Lebu;
    private bool _isMove;
    private void Start()
    {
        StartSetting();
    }

    private void Update()
    {
        LebuMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(MoveStart());
        }
    }

    private IEnumerator MoveStart()
    {
        _isMove = true;
        yield return new WaitForSeconds(2f);
        _isMove = false;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(4).gameObject.SetActive(true);

    }
    private void StartSetting()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        _Lebu = transform.GetChild(0).gameObject;
    }

    private void LebuMove()
    {
        if (_isMove)
            _Lebu.transform.rotation = Quaternion.Lerp(_Lebu.transform.rotation, Quaternion.Euler(0f, 0f, 45f), 0.01f);
    }
}
