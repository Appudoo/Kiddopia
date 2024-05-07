using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Buzzle_GameManager : MonoBehaviour
{
    public GameObject optionPanel;
    public SpriteRenderer Img;
    public List<GameObject> buzzleSprite;

    public int countImg;
    public int totalcounting;

    public static Buzzle_GameManager Instance;

    public GameObject Winpanel;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        OnCompleteSetSprite();
    }

    public void OnCompleteSetSprite()
    {
        if(totalcounting<=countImg)
        {
            print("Win");
            int L = PlayerPrefs.GetInt("Level6");
            if(L !=  Buzzle.Instance.Level.Length)
            {
                L++;
            }
           
            PlayerPrefs.SetInt("Level6", L);
            Winpanel.SetActive(true);
            optionPanel.SetActive(false);
        }
        else
        {
            print("Hello");
            optionPanel.transform.position = new Vector2(transform.position.x, -3.5f);
            optionPanel.transform.DOMoveY(0, 1f);
            optionPanel.SetActive(true);
            buzzleSprite[countImg].SetActive(true);
            countImg++;
        }
        
    }

    public void OnClickHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.Buzzle);
    }

}
