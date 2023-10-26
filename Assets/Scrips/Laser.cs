using UnityEngine;

public enum Type  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
{

    Laser,
    a,
    b,
    c,
    d,
    e,
    f
}
public class Laser : MonoBehaviour
{
    public Player player;
    public ParticleSystem ps;
    public Type gimic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("ㅎㅎㅎㅎㅎㅎ");
            // playerConditions.health.curValue -= 1f;
            //  Player.health -= 2;
            //  Debug.Log("ºÒ·Î¸ÂÀºÃ¼·Â " + Player.health);
            //player.moveVec = new Vector3(0, 0, 0);
            // Debug.Log(player.moveVec);
            //StartCoroutine("player.SturnStart()");
            switch (gimic)
            {
                case Type.Laser:
                    player.StartSturnCoroutine();
                    break;
                case Type.a:
                    player.LotateStartCoroutine();
                    Debug.Log("나는 토네이토야");
                    break;
                case Type.b: break;
                case Type.c: break;
            }

        }
    }
}
