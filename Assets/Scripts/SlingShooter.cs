using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShooter : MonoBehaviour
{
    public CircleCollider2D Collider;
    // posisi awal sebelum karet ditarik
    private Vector2 _startPos;

    [SerializeField]
    // panjang karet
    private float _radius = 0.75f;

    [SerializeField]
    // kecepatan awal yang dierikan ketapel
    private float _throwSpeed = 30f;

    // Tambahan dari Scripting GameController
    private Bird _bird;

    void Start()
    {
        _startPos = transform.position;
    }

    void OnMouseUp()
    {
        Collider.enabled = false;
        Vector2 velocity = _startPos - (Vector2)transform.position;
        float distance = Vector2.Distance(_startPos, transform.position);
        
        // Tambahan dari Scripting GameController
        _bird.Shoot(velocity, distance, _throwSpeed);

        //Kembalikan ketapel ke posisi awal
        gameObject.transform.position = _startPos;

    }

    void OnMouseDrag()
    {
        // Mengubah posisi mouse ke world position
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Hitung supaya 'karet' ketapel berada dalam radius yang ditentukan
        Vector2 dir = p - _startPos;
        if (dir.sqrMagnitude > _radius)
            dir = dir.normalized * _radius;
        transform.position = _startPos + dir;
    }

    // Tambahan dari Scripting GameController
    public void InitiateBird(Bird bird)
    {
        _bird = bird;
        _bird.MoveTo(gameObject.transform.position, gameObject);
        Collider.enabled = true;
    }
}
