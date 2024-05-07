using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleDragandDrop : MonoBehaviour
{
    public bool IsCollide;
    public Vector2 CurrPostion;
    public Vector3 scale;
    public Vector3 ClickScale;
    public GameObject selecObj;
    private void Awake()
    {

    }
    private void Start()
    {
        CurrPostion = transform.position;
        scale = transform.localScale;
    }
    private void OnMouseDown()
    {
        transform.DOScale(new Vector3(0.5f, 0.5f, 1f), 0.2f);

    }
    private void OnMouseDrag()
    {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePostion.x, mousePostion.y, 0);
    }
    private void OnMouseUp()
    {
        if (!IsCollide)
        {
            transform.DOMove((CurrPostion), 0.5f).OnUpdate(() =>
            {
                transform.DOScale(scale, 0.5f);
            });

        }
        else
        {
            PuzzleManager.instance.cnt++;
            selecObj.GetComponent<SpriteRenderer>().color = Color.white;
            selecObj.GetComponent<BoxCollider2D>().enabled = false;
            PuzzleManager.instance.OnCompleteSetSprite();
            this.gameObject.SetActive(false);
            //Targetobject.GetComponent<SpriteRenderer>().color = Color.white;
            //Buzzle_GameManager.Instance.OnCompleteSetSprite();
            Destroy(this.gameObject);
            if(PuzzleManager.instance.cnt==6)
            {
                PuzzleManager.instance.CurrectEat();

            }
        }

    }
    private void Update()
    {
        //if (PuzzleManager.instance.countImg == PuzzleManager.instance.totalcounting)
        //{
        //    PuzzleManager.instance.Winpanel.SetActive(true);
        //    PuzzleManager.instance.Animal.GetComponent<SpriteRenderer>().enabled = false;
        //    Debug.Break();
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name == this.GetComponent<SpriteRenderer>().sprite.name)
        {
            Debug.Log("hello");
            IsCollide = true;
            selecObj = collision.gameObject;

            //PuzzleManager.instance.CurrectEat();


            //Destroy(this.gameObject);



        }
        else
        {
            IsCollide = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsCollide = false;
    }
}
