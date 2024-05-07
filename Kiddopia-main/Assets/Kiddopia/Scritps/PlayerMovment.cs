using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovment : MonoBehaviour
{
    public Vector2 targetPostion;
    public Animator animator;
    public int playerstop;
    public float targetX;
    public int MoveCount;
    private void Start()
    {
        animator.speed = 0;
    }
    public void OnClickRun()
    {
        if (AllGameManager.Instance.g.Length > 1)
        {
            if (!AllGameManager.Instance.g[0].GetComponent<CurectPosition>().isPlaced)
            {
                return;
            }
            if (AllGameManager.Instance.g[0].GetComponent<CurectPosition>().isPlaced)
            {
                targetX = AllGameManager.Instance.g[0].GetComponent<CurectPosition>().position.x;
                if (AllGameManager.Instance.g[1].GetComponent<CurectPosition>().isPlaced)
                {
                    targetX = targetPostion.x;
                    MoveCount = 1;
                }
            }
        }
        else
        {
            targetX = targetPostion.x;
        }


        animator.speed = 1;
        transform.DOMoveX(targetX, 4f).OnComplete(() =>
        {
            animator.speed = 0;
            if (AllGameManager.Instance.g.Length > 1)
            {
                MoveCount++;
                if (MoveCount == 2)
                {
                    int L = PlayerPrefs.GetInt("Level3");
                    L++;
                    PlayerPrefs.SetInt("Level3", L);
                    AllGameManager.Instance.WinPanel.SetActive(true);
                }
            }
            else
            {
                int L = PlayerPrefs.GetInt("Level3");
                L++;
                PlayerPrefs.SetInt("Level3", L);
                AllGameManager.Instance.WinPanel.SetActive(true);
            }


        });
    }
}
