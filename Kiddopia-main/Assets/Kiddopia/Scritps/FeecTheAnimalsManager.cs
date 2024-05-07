using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeecTheAnimalsManager : MonoBehaviour
{
    public static FeecTheAnimalsManager Instance;

    public List<Sprite> beforeAnimImg;
    public List<Sprite> afterAnimImg;
    public SpriteRenderer mainImg;

    bool Iseat;
    int animationIndex;
    public GameObject Particle;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //leveltxt.text = "Level : "+PlayerPrefs.GetInt("FeedTheAnimal").ToString();
        //OnClickNextLevel(0);
        //InvokeRepeating("ANimation", 0f, 0.05f);
    }
    public void CurrectEat()
    {
        print("---Dog---");
        Particle.SetActive(true);
        animationIndex = 0;
        Iseat = true;
        mainImg.GetComponent<Animator>().SetBool("Iseat",true);
        animationIndex = 0;
        //dogAnimator.Play(dogeatingClip.name);
        DOTween.Sequence().AppendInterval(4f).OnComplete(() => {
            int aa = PlayerPrefs.GetInt("FeedTheAnimal");
            aa++;
            if(aa<24)
            {
                PlayerPrefs.SetInt("FeedTheAnimal", aa);
                OnClickNextLevel();
            }
            else
            {
                OnClicHome();
            }
           

        });
        
    }

    private void FixedUpdate()
    {

        
    }

    public void OnClickNextLevel()
    {
        Destroy(HomeManager.instance.L);
        int l = PlayerPrefs.GetInt("FeedTheAnimal");
        FeedAnimal.Instance.levelNo += 1;
        PlayerPrefs.SetInt("level",FeedAnimal.Instance.levelNo);
        GameObject L = Instantiate(FeedAnimal.Instance.Levels[l]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }

    public void OnClicHome()
    {
        DOTween.KillAll();
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }

    void ANimation()
    {
        if (!Iseat)
        {
            if (animationIndex < beforeAnimImg.Count - 1)
            {
                animationIndex++;
            }
            else
            {
                animationIndex = 0;
            }
            mainImg.sprite = beforeAnimImg[animationIndex];

        }
        else
        {
            print("Eat");
            if (animationIndex < afterAnimImg.Count - 1)
            {
                animationIndex++;
            }
            else
            {
                animationIndex = 0;
            }
            mainImg.sprite = afterAnimImg[animationIndex];
        }
    }

}

//public class FeecAnimalImg
//{
//    public Image currectImg;
//    public List<Image> Images;
//}
