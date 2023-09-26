using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bear;
    public static int bearNum;  //곰돌이 수
    public Transform respwanPos;
    public Player player;
    float scale;

    private static GameManager Instance;  //싱글톤 진행


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        bearNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BearRespwan()
    {
        if (bearNum == 0)
        {
            scale = Random.Range(1F, 5F);
            GameObject bears = Instantiate(bear, respwanPos.position, Quaternion.identity);
            bears.GetComponent<NPC>().player = player;
            bears.transform.localScale = new Vector3(scale, scale, scale);
            bearNum++;
        }
    }

    public void BearDie()
    {
        bearNum--;
    }
}


//게임 메니저 싱글톤화 진행하고 어왜이크에 있는거 다 메서드로 바꾸고
// 타입을 선언해서 각 몬스터마다 어떻게 해야하는지 보여주기