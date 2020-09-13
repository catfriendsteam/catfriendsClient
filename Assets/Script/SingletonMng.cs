using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMng : MonoBehaviour
{
    public static SingletonMng instance;

    public long Money;
    public int Diamond;
    public int GoodPoint;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
