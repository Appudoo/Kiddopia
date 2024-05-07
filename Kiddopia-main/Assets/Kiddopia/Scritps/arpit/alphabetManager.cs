using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabetManager : MonoBehaviour
{
    public static alphabetManager instance;
    public int stage = 0;
    public List<GameObject> list;
    public GameObject partical, win;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        loadStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == list.Count)
        {
            stage = 0;
            CheckWin();
        }
    }

    public void loadStage()
    {
        if (stage <= list.Count)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetActive(false);
            }
            list[stage].SetActive(true);
        }

    }

    public void CheckWin()
    {
        Debug.Log("hello");
        partical.SetActive(true);
        DOTween.Sequence().AppendInterval(1f).OnComplete(() =>
        {
            win.SetActive(true);
            partical.SetActive(false);

        });

    }

    public void onclickBakc()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }
}
