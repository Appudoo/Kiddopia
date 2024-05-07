using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Slider slider;

    public int rightanswer;

    public List<countnumber> countnumbers = new List<countnumber>();
    public List<GameObject> g;
    public int currentlevel;

    public List<GameObject> topOption;

    public Button firstbtn, secondbtn, thirdbtn;

    private void Start()
    {
        levelmanager();
    }

    void levelmanager()
    {
        print("KKKK");
        firstbtn.interactable = true;
        secondbtn.interactable = true;
        thirdbtn.interactable = true;
        foreach (GameObject go in topOption)
        {
            go.transform.localScale = new Vector3(0,0,0);
        }
        
        slider.maxValue = 10;
        slider.value = currentlevel;
        foreach (var item in topOption)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < countnumbers[currentlevel].rightanswer; i++)
        {
            topOption[i].gameObject.SetActive(true);
            topOption[i].gameObject.transform.DOScale(new Vector3(1f,1f,1f),1f);
            topOption[i].GetComponent<Image>().sprite = countnumbers[currentlevel].mainProduc;
        }
        firstbtn.onClick.RemoveAllListeners();
        secondbtn.onClick.RemoveAllListeners();
        thirdbtn.onClick.RemoveAllListeners();
        firstbtn.onClick.AddListener(() => {
            print("Abhi");
            Checkbutton(firstbtn, countnumbers[currentlevel].firstprice);
        });
        secondbtn.onClick.AddListener(() => {
            print("Abhi");
            Checkbutton(secondbtn, countnumbers[currentlevel].secondprice);
        });
        thirdbtn.onClick.AddListener(() => {
            print("Abhi");
            Checkbutton(thirdbtn, countnumbers[currentlevel].thirdprice);
        });
        firstbtn.transform.GetChild(0).transform.GetComponent<Text>().text = countnumbers[currentlevel].firstprice.ToString();
        secondbtn.transform.GetChild(0).transform.GetComponent<Text>().text = countnumbers[currentlevel].secondprice.ToString();
        thirdbtn.transform.GetChild(0).transform.GetComponent<Text>().text = countnumbers[currentlevel].thirdprice.ToString();

        firstbtn.interactable = true;
        secondbtn.interactable = true;
        thirdbtn.interactable = true;
        rightanswer = countnumbers[currentlevel].rightanswer;

        for (int i = 0; i < 3; i++)
        {
            firstbtn.transform.localScale = new Vector3(0,0,0);
            secondbtn.transform.localScale = new Vector3(0,0,0);
            thirdbtn.transform.localScale = new Vector3(0,0,0);

            firstbtn.transform.DOScale(new Vector3(1f,1f,1f),1f);
            secondbtn.transform.DOScale(new Vector3(1f,1f,1f),1f);
            thirdbtn.transform.DOScale(new Vector3(1f,1f,1f),1f);
        }
        firstbtn.interactable = true;
        secondbtn.interactable = true;
        thirdbtn.interactable = true;
    }

    public void Checkbutton(Button btn,int number)
    {
        print("Hello");
        if(rightanswer==number)
        {
            print("Win");
            currentlevel++;
            for(int i=0;i<currentlevel;i++)
            {
                g[i].gameObject.SetActive(true);
            }
            if (currentlevel == 7)
            {
                AllGameManager.Instance.WinPanel.SetActive(true);
                return;
            }
            levelmanager();
            firstbtn.interactable = true;
            secondbtn.interactable = true;
            thirdbtn.interactable = true;
            if(currentlevel==7)
            {
                AllGameManager.Instance.WinPanel.SetActive(true);
            }
        }
        else
        {

            btn.interactable = false;
        }
    }
}

[System.Serializable]
public class countnumber
{
    public Sprite mainProduc;
    public int firstprice;
    public int secondprice;
    public int thirdprice;
    public int rightanswer;
}
