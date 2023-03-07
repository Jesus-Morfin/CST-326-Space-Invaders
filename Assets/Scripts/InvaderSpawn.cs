using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderSpawn : MonoBehaviour
{
    //Using an array of prefabs
    public InvadersAnimation[] prefabs;

    
    //Total rows and columns of invaders
    private int rows = 5;
    private int columns = 6;
    
    public int totalInvaderDestroyed { get; private set; }
    public int totalInvaders => rows * columns;
    public int invadersTracker => totalInvaderDestroyed / totalInvaders;

    public AnimationCurve speed;

    private float invaderSpeed = 2.0f;
    
    //Using a Vector3 to find the direction of the Camera for later
    private Vector3 direction = Vector2.right;
    private Camera _camera;

    void Start()
    {
        
        _camera = Camera.main;
        
        //The two for loops is to spawn the invaders
        for (int i = 0; i < this.rows; i++)
        {
            Vector3 horizontalPosition = new Vector3(0.0f, i * 1.5f, 0.0f);
            for (int j = 0; j < this.columns; j++)
            {
                InvadersAnimation invaders = Instantiate(this.prefabs[i], transform);
                invaders.invaderDestroyed += InvaderDestroyed;
                Vector3 pos = horizontalPosition;
                pos.x += j * 1.5f;
                invaders.transform.position = pos;

            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * (this.speed.Evaluate(invadersTracker) * Time.deltaTime);
        Vector3 leftWall = -_camera.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightWall = _camera.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invaders in this.transform)
        {
            if (!invaders.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (direction == Vector3.right && invaders.position.x >= (rightWall.x - 1.0f))
            {
                DownOneRow();
            } 
            else if (direction == Vector3.left && invaders.position.x >= (leftWall.x + 1.0f))
            {
                DownOneRow();
            }
        }
    }

    private void DownOneRow()
    {
        direction.x *= -1.0f;
        var transform1 = this.transform;
        Vector3 pos = transform1.position;
        pos.y -= 0.2f;
        transform1.position = pos;
    }

    private void InvaderDestroyed()
    {
        Destroy(this.gameObject);
    }

    
}
