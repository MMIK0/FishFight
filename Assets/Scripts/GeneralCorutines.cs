using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCorutines : MonoBehaviour
{
    public static GeneralCorutines Instance;
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LastStand(GameObject g,float time= 1f)
    {
        yield return new WaitForSeconds(time);
        g.SetActive(false);
    }
}
