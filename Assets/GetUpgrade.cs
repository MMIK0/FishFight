using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpgrade : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        UiManager.instance.OpenUpgradeMenu();
        Destroy(this.gameObject);
    }

}
