﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OnefallGames;
using TMPro;
public class BallController : MonoBehaviour {

    [HideInInspector]
    public int number = 1;
    [HideInInspector]
    public float fallingSpeed = 0;

    public bool IsVisible { private set; get; }


    [SerializeField]
    private TextMeshProUGUI numberText = null;

    private SpriteRenderer spRender = null;
    private float scaleDownFactor;
    

    public void MoveBall()
    {
        if (spRender == null)
            spRender = GetComponent<SpriteRenderer>();

        scaleDownFactor = (transform.localScale.x - GameManager.Instance.minBallScale) / (number - 1);
        numberText.text = number.ToString();
        StartCoroutine(MoveDown());
    }


    IEnumerator MoveDown()
    {
        while (gameObject.activeInHierarchy)
        {
            Vector2 pos = transform.position;
            pos += Vector2.down * fallingSpeed * Time.deltaTime;
            transform.position = pos;
            yield return null;

            if (GameManager.Instance.GameState != GameState.Playing)
            {
                DisableObject();
                yield break;
            }

            if (!IsVisible)
            {
                Vector2 currentPos = (Vector2)transform.position + Vector2.down * (spRender.bounds.size.y / 2);
                float y = Camera.main.WorldToViewportPoint(currentPos).y;
                if (y < 1f)
                    IsVisible = true;
            }

            Vector2 checkPos = (Vector2)transform.position + Vector2.up * spRender.bounds.size.y;
            if (checkPos.y < PlayerController.Instance.limitBottom)
            {
                StartCoroutine(SetGameOver());
                yield break;
            }
        }
    }

    IEnumerator SetGameOver()
    {
        ShareManager.Instance.CreateScreenshot();
        yield return null;
        GameManager.Instance.Revive();
        DisableObject();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsVisible)
        {
            if (collision.CompareTag("Bullet"))
            {
                if (int.Parse(numberText.text) == 1)
                {
                    DisableObject();
                    GameManager.Instance.CreateBoostUp(transform.position);
                }
                else
                {
                    float newScale = transform.localScale.x - scaleDownFactor;
                    newScale = (newScale >= GameManager.Instance.minBallScale) ? newScale : GameManager.Instance.minBallScale;
                    transform.localScale = new Vector3(newScale, newScale, 1);
                    int newNumber = int.Parse(numberText.text) - 1;
                    numberText.text = newNumber.ToString();

                    ScoreManager.Instance.AddScore(1);
                }
            }
            else if (collision.CompareTag("Destroy"))
            {
                DisableObject();
                GameManager.Instance.CreateBoostUp(transform.position);
            }
        }    
    }


    void DisableObject()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.ballExplore);
        GameManager.Instance.PlayBallExplode(transform.position);
        gameObject.SetActive(false);
        IsVisible = false;
    }
}
