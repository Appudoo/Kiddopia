using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    
    public int countImg;
    public int totalcounting;
    public GameObject Winpanel,win;
    public GameObject Animal;
    public int cnt = 0;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    private void Update()
    {
       
    }
    public void CurrectEat()
    {
        print("---Dog---");
        //cnt++;
        
            cnt = 0;
            Winpanel.SetActive(true);
            //dogAnimator.Play(dogeatingClip.name);
            DOTween.Sequence().AppendInterval(4f).OnComplete(() => {
                //int aa = PlayerPrefs.GetInt("puzzleTheAnimal");
                //aa++;
                //if (aa < 24)
                //{
                //    PlayerPrefs.SetInt("puzzleTheAnimal", aa);
                //    OnClickNextLevel();
                //}
                //else
                //{
                //    //OnClicHome();
                //}
                win.SetActive(true);


            });
        
       

    }

    private void FixedUpdate()
    {


    }

    public void OnClickNextLevel()
    {
        Destroy(HomeManager.instance.L);
        int l = PlayerPrefs.GetInt("puzzleTheAnimal");
        puzzleanimal.instance.levelNo += 1;
        PlayerPrefs.SetInt("level", puzzleanimal.instance.levelNo);
        GameObject L = Instantiate(puzzleanimal.instance.Levels[l]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }
    public void OnCompleteSetSprite()
    {
        if (totalcounting == countImg)
        {
            print("Win");
            int L = PlayerPrefs.GetInt("Level6");

            L++;
            PlayerPrefs.SetInt("Level6", L);
            //Winpanel.SetActive(true);
            

        }
        else
        {
            print("Hello");
           
            totalcounting++;
        }

    }
    public void OnClicHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }
}
