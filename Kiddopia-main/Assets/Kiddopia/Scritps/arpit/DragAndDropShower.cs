using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropShower : MonoBehaviour
{
    public bool IscurrctObject;
    public Vector2 Currentposition;
    // public Transform RightPosition;
    public GameObject partical, shower;
    public GameObject parent;
    public GameObject selectedobj;
    bool IsSet;
    bool Shower, soap, Towel;
    bool iswin;
    public PlayerMovment playerMovment;



    private void Start()
    {
        partical.SetActive(false);
        Currentposition = transform.position;
    }

    private void OnMouseDrag()
    {
       
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePostion.x, mousePostion.y, 0);
        if (this.tag == "shower")
        {
            shower.gameObject.SetActive(true);
        }


    }
    private void Update()
    {

    }

    private void OnMouseUp()
    {
        if (this.tag == "shower")
        {
            shower.gameObject.SetActive(false);
        }
        if (!IscurrctObject)
        {
            transform.position = Currentposition;
        }
        else
        {
            if (!IsSet)
            {
                transform.position = Currentposition;
            }
            else
            {
                selectedobj.GetComponent<SpriteRenderer>().color = Color.white;
                if (HomeManager.instance.gameIndex == 0)
                {
                    FeecTheAnimalsManager.Instance.CurrectEat();
                }
                //else if (HomeManager.instance.gameIndex == 3)
                //{
                //    playerMovment.OnClickRun();
                //}

                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Currect")
        {
            if (this.tag == "shower")
            {
                //shower.gameObject.SetActive(true);
            }
            else if (this.tag == "soap")
            {
                GameObject g = Instantiate(partical);
                //g.GetComponent<ParticleSystem>().playOnAwake=true;
                g.SetActive(true);
                g.transform.position = transform.position;
                g.transform.localScale = Vector3.one;
                g.transform.SetParent(parent.transform);
                BathAnimalManager.Instance.stage = Stage.Towel;
            }
            else if(this.tag == "towel")
            {

                if (parent.transform.childCount > 0)
                {
                    Destroy(parent.transform.GetChild(parent.transform.childCount - 1).gameObject);
                }
            }
        }
        if (!iswin)
        {
            Debug.Log("hello");
            if (parent.transform.childCount == 0 && BathAnimalManager.Instance.stage == Stage.Towel)
            {
                iswin = true;
                DOTween.Sequence().AppendInterval(0f).OnComplete(() =>
                {
                    BathAnimalManager.Instance.CurrectEat();
                    Debug.Log("hellllllllllllllllllllllllll");

                    this.gameObject.transform.position = Currentposition;
                    //OnClickNextLevel();
                });

            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "soap")
        {
                BathAnimalManager.Instance.stage = Stage.Towel;
        }

    }

    public void OnClickNextLevel()
    {

        Destroy(HomeManager.instance.L);
        int l = PlayerPrefs.GetInt("BathTheAnimal");
        Debug.Log(l);
        Bath_Aimal.Instance.levelNo += 1;
        PlayerPrefs.SetInt("level", Bath_Aimal.Instance.levelNo);
        for (int i = 0; i < Bath_Aimal.Instance.AnimalsLevel.Count; i++)
        {
            Bath_Aimal.Instance.AnimalsLevel[i].GetComponent<CanvasGroup>().interactable = false;
        }
        for (int i = 0; i < Bath_Aimal.Instance.levelNo; i++)
        {
            Bath_Aimal.Instance.AnimalsLevel[i].GetComponent<CanvasGroup>().interactable = true;
            Bath_Aimal.Instance.AnimalsLevel[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        GameObject L = Instantiate(Bath_Aimal.Instance.Levels[l]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
        Debug.Log(l);


    }
}
