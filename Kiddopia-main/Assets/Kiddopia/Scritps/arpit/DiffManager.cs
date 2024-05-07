using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class DiffManager : MonoBehaviour
{
    public static DiffManager instance; 
    public List<GameObject> TotalBtn;
    public GameObject winPanel,partical;
    public int DiffCount = 0,c=0;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Check()
    {
        c = 0;
        for (int i = 0; i < TotalBtn.Count; i++)
        {
            if (TotalBtn[i].GetComponent<Image>().color==Color.white)
            {
                c++;
            }
        }
        if(c==TotalBtn.Count)
        {
            Win();
        }
    }
    
    public void Win()
    {
        partical.SetActive(true);
        DOTween.Sequence().AppendInterval(2f).OnComplete(() =>{
            winPanel.gameObject.SetActive(true);
        });
    }
    public void OnClicHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }

    public void OnClickNextLevel()
    {
        Destroy(HomeManager.instance.L);
        int l = PlayerPrefs.GetInt("diffTheAnimal");
        diffANimal.instance.levelNO+=1;
        PlayerPrefs.SetInt("levelpuzzle",diffANimal.instance.levelNO);
        GameObject L = Instantiate(diffANimal.instance.level[l+1]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();

    }

}
