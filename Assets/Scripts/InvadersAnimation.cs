using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
public class InvadersAnimation : MonoBehaviour
{
    public Sprite[] animation;
    public float animationSpeed = 20f;
    
    public TextMeshProUGUI Score;
    public TextMeshProUGUI  HighScore;
    
    public System.Action invaderDestroyed;
    private SpriteRenderer _spriteRenderer;
    
    private int score = 0;
    private int highScore;
    
    private int frames;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        InvokeRepeating(nameof(SpriteAnimation), this.animationSpeed, this.animationSpeed);
    }

    private void SpriteAnimation()
    {
        frames++;

        if (frames >= this.animation.Length)
        {
            frames = 0;
        }

        _spriteRenderer.sprite = this.animation[frames];
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Invader 1"))
        {
            score += 10;
            totalScore();
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Invader 2"))
        {
            score += 20;
            totalScore();
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Invader 3"))
        {
            score += 30;
            totalScore();
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Mystery Ship"))
        {
            int randomNumber = Random.Range(50, 300);
            score += randomNumber;
            totalScore();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    
    private void totalScore()
    {
        if (score < 100)
        {
            this.Score.text = "00" + score.ToString();
            if (highScore < score)
            {
                highScore = score;
                if (highScore < 100)
                {
                    this.Score.text = "00" + highScore.ToString();
                }
                else if (highScore < 1000)
                {
                    this.Score.text = "0" + highScore.ToString();
                }
                else
                {
                    this.Score.text =  highScore.ToString();
                }
            }
        }
        else if (score < 1000)
        {
            this.Score.text = "0" + score.ToString();
        }
        else
        {
            this.Score.text =  score.ToString();
        }
    }



}
