using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;

    public bool isGamePlay = false;

    void Awake()
    {
        if(sharedInstance != null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
