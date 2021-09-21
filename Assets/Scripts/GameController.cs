﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Bird> Birds;

    void Start()
    {
        // Tambahan Eveny delegate
        for(int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
        }
        SlingShooter.InitiateBird(Birds[0]);
    }

    // Tambahan Eveny delegate
    public void ChangeBird()
    {
        Birds.RemoveAt(0);

        if(Birds.Count > 0)
            SlingShooter.InitiateBird(Birds[0]);
    }
}
