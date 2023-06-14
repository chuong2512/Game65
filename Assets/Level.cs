using System.Collections;
using System.Collections.Generic;
using RObo;
using UnityEngine;

public class Level : Singleton<Level>
{
    public Fish[] fishes;


    void OnValidate()
    {
        fishes = GetComponentsInChildren<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Check()
    {
        fishes = GetComponentsInChildren<Fish>();

        if (fishes == null || fishes.Length == 0)
        {
            TheGameUI.Instance.ShowWin();
        }
    }
}