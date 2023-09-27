using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject bear;
    public  int bearNum;  //곰돌이 수
    public Transform bearRespwanPos;


    
    public Player player;
    float scale;

    public static GameManager Instance;  //싱글톤 진행


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

    private void Start()
    {
        BearRespwan();
    }

    // Update is called once per frame
    void Update()
    {
        BearRespwan();
    }

    void BearRespwan()
    {
        if (bearNum < 1)
        {

            scale = Random.Range(1F, 3F);
            GameObject bears = Instantiate(bear, bearRespwanPos.position, Quaternion.identity);
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

//이건 스폰매니저로 만들어야할 듯
//게임 메니저 싱글톤화 진행하고 어왜이크에 있는거 다 메서드로 바꾸고
// 타입을 선언해서 각 몬스터마다 어떻게 해야하는지 보여주기