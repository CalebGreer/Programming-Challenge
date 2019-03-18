using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            Destroy(this.gameObject);
            HUDManager.Instance.IncreaseScore();
        }
    }

}
