using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Type
    {
        Ammo,
        Coin,
        Grenade,
        Heart,
        Weapon
    }

    public Type type;
    public int value;

    private void Update()
    {
        transform.Rotate(Vector3 .up * Time.deltaTime *20);
    }
}
