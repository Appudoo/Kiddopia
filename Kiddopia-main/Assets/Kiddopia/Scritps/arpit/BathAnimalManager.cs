using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Shower,Soap,Towel
}
public class BathAnimalManager : MonoBehaviour
{
    public static BathAnimalManager Instance;

    public List<Sprite> beforeAnimImg;
    public List<Sprite> afterAnimImg;
    public SpriteRenderer mainImg;
    public Stage stage;
    bool Iseat;
    int animationIndex;
    public GameObject Particle;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        stage = Stage.Shower;
        //leveltxt.text = "Level : "+PlayerPrefs.GetInt("FeedTheAnimal").ToString();
        //OnClickNextLevel(0);
    }
    public void CurrectEat()
    {
        print("---Dog---");
        Particle.SetActive(true);
        //Debug.Break();
        animationIndex = 0;
        Iseat = true;
        animationIndex = 0;
        //dogAnimator.Play(dogeatingClip.name);
        DOTween.Sequence().AppendInterval(4f).OnComplete(() => {
            int aa = PlayerPrefs.GetInt("BathTheAnimal");
            aa++;
            Debug.Log("aaaaaaaaaaaaaaa" + aa);
            if (aa < Bath_Aimal.Instance.Levels.Count)
            {
                PlayerPrefs.SetInt("BathTheAnimal", aa);
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
        int l = PlayerPrefs.GetInt("BathTheAnimal");
        Debug.Log(l);
        Bath_Aimal.Instance.levelNo += 1;
        PlayerPrefs.SetInt("level", Bath_Aimal.Instance.levelNo);
        //for (int i = 0; i < Bath_Aimal.Instance.AnimalsLevel.Count; i++)
        //{
        //    Bath_Aimal.Instance.AnimalsLevel[i].GetComponent<Canv asGroup>().interactable = false;
        //}
        //for (int i = 0; i < Bath_Aimal.Instance.levelNo; i++)
        //{
        //    Bath_Aimal.Instance.AnimalsLevel[i].GetComponent<CanvasGroup>().interactable = true;
        //    Bath_Aimal.Instance.AnimalsLevel[i].transform.GetChild(0).gameObject.SetActive(false);
        //}
        GameObject L = Instantiate(Bath_Aimal.Instance.Levels[l]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
        Debug.Log(l);
    }


    public void OnClicHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }



}

    //public class FeecAnimalImg
    //{
    //    public Image currectImg;
    //    public List<Image> Images;
    //}
