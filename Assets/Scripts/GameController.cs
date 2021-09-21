using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Bird> Birds;
    // Tambahan Scripting Enemy
    public List<Enemy> Enemies;

    // Tambahan Scripting Enemy
    private bool _isGameEnded = false;


    void Start()
    {
        // Tambahan Eveny delegate
        for(int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
        }

        // Tamabhan Scripting ENemy
        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        SlingShooter.InitiateBird(Birds[0]);
    }

    // Tambahan Eveny delegate
    public void ChangeBird()
    {
        // Tambahan Scripting Enemy
        if (_isGameEnded)
        {
            return;
        }

        Birds.RemoveAt(0);

        if(Birds.Count > 0)
            SlingShooter.InitiateBird(Birds[0]);
    }

    // Tambahan Scripting Enemy
    public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }

        if(Enemies.Count == 0)
        {
            _isGameEnded = true;
        }
    }
}
