using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointjointmanager : MonoBehaviour
{
    public static pointjointmanager instance;
    public List<GameObject> PointList;
    public int pointCount;
    public Vector2 trunPOS, TargetPOS;
    public SpriteRenderer sprite;
    public GameObject partical,point,winpanel
        ;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PointList[1].GetComponent<dragHandler>().Target = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeTarget()
    {
        for (int i = 0; i < PointList.Count; i++)
        {
            PointList[i].GetComponent<dragHandler>().Target = false;
            PointList[i].GetComponent<dragHandler>().iscurrentTrun = false;
        }
        PointList[pointCount].GetComponent<dragHandler>().iscurrentTrun = true;
        if(pointCount<10)
        PointList[pointCount + 1].GetComponent<dragHandler>().Target = true;
        PointList[pointCount].GetComponent<BoxCollider2D>().size = trunPOS;
        if (pointCount < 10)
            PointList[pointCount+1].GetComponent<BoxCollider2D>().size = TargetPOS;

    }

    public void win()
    {
        partical.SetActive(true);
        point.SetActive(false);
        sprite.GetComponent<SpriteRenderer>().DOFade(1, 1f);
       
        DOTween.Sequence().AppendInterval(5f).OnComplete(() =>
        {
            partical.SetActive(false);
            winpanel.SetActive(true);
        });
    }
    public void OnClicHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.ABCAnimalsAdventures);
    }
}
