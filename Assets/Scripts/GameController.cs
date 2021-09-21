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
    
    public TrailController TrailController;

    // Tambahan Scripting Enemy
    private bool _isGameEnded = false;

    // Tambahan Inheritance
    private Bird _shotBird;
    public BoxCollider2D TapCollider;


    void Start()
    {
        // Tambahan Eveny delegate
        for(int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
            // Tambahan Scripting COntroller
            Birds[i].OnBirdShot += AssignTrail;
        }

        // Tamabhan Scripting ENemy
        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        // Tambahan Inheritance
        TapCollider.enabled = false;

        SlingShooter.InitiateBird(Birds[0]);
        // Tambahan Inheritance
        _shotBird = Birds[0];
    }

    // Tambahan Eveny delegate
    public void ChangeBird()
    {
        TapCollider.enabled = false;

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

    // Tambahan Scripting trail
    public void AssignTrail(Bird bird)
    {
        TrailController.SetBird(bird);
        StartCoroutine(TrailController.SpawnTrail());
        // Tambahan Inheritance
        TapCollider.enabled = true;
    }

    // Tambahan Inheritance
    void OnMouseUp()
    {
        if(_shotBird != null)
        {
            _shotBird.OnTap();
        }
    }
}
