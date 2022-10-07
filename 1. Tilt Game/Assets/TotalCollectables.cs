using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCollectables : MonoBehaviour
{
    public float collectables;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        collectables = 0;
    }
    public void AddCollectables()
    {
        collectables += 1;
    }
}
