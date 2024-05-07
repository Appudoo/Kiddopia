using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabet : MonoBehaviour
{
    public Vector2 currentPos;
    public bool isMove;
    public List<GameObject> ObjList;
    private void Start()
    {
        currentPos = transform.position;
    }
    private void OnMouseDown()
    {
        Debug.Log("hkcsjkjds");
        isMove = true;
    }
    private void OnMouseDrag()
    {
        if (isMove)
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.DOMove(p, 0.0001f);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    isMove = true;

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "last")
        {
            isMove = false;
            //Debug.Log("c ",collision.);
            this.transform.position = collision.gameObject.transform.position;
            this.GetComponent<CircleCollider2D>().enabled = false;

            DOTween.Sequence().AppendInterval(1f).OnComplete(() =>
            {


                alphabetManager.instance.stage++;
                alphabetManager.instance.loadStage();
                

            });

        }
        if (collision.gameObject.tag == "obj")
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "path" && isMove)
        {
            isMove = false;
            transform.position = currentPos;
            foreach (GameObject g in ObjList)
            {
                g.SetActive(true);
            }
        }
    }


}
