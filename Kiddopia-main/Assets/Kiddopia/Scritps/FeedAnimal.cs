using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAnimal : MonoBehaviour
{
    public static FeedAnimal Instance;
    public List<GameObject> Levels;
    public List<GameObject> AnimalsLevel;
    public int levelNo;
    public float top = 5f;
    public float bottom = -5f;
    public float left = -5f;
    public float right = 5f;
    private void OnEnable()
    {
        //Levels.AddRange(SplashManager.instance.list);
        //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,Screen.height);
    }
    private void Awake()
    {
        Instance = this;
        if (!PlayerPrefs.HasKey("level"))
        {
            levelNo = 1;
            PlayerPrefs.SetInt("level", levelNo);
        }
        else
        {
            levelNo = PlayerPrefs.GetInt("level");
        }
    }

    private void Start()
    {
        for (int i = 0; i < AnimalsLevel.Count; i++)
        {
            //AnimalsLevel[i].GetComponent<CanvasGroup>().interactable = true;
            AnimalsLevel[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        //for (int i = 0; i < levelNo; i++)
        //{
        //    AnimalsLevel[i].GetComponent<CanvasGroup>().interactable= true;
        //    AnimalsLevel[i].transform.GetChild(0).gameObject.SetActive(false);
        //}
    }
    public void OnClickFeedTheAnimal(int index)
    {
        PlayerPrefs.SetInt("FeedTheAnimal", index);
        Debug.Log(index);
        GameObject L = Instantiate(Levels[index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }

}
