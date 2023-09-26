using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bear;
    public static int bearNum;  //������ ��
    public Transform respwanPos;
    public Player player;
    float scale;

    private static GameManager Instance;  //�̱��� ����


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


//���� �޴��� �̱���ȭ �����ϰ� �����ũ�� �ִ°� �� �޼���� �ٲٰ�
// Ÿ���� �����ؼ� �� ���͸��� ��� �ؾ��ϴ��� �����ֱ�