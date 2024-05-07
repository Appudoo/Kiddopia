using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool IscurrctObject;
    public Vector2 Currentposition;
    // public Transform RightPosition;

    public GameObject selectedobj;
    bool IsSet;

    public PlayerMovment playerMovment;



    private void Start()
    {
        Currentposition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePostion.x, mousePostion.y, 0);
    }

    private void OnMouseUp()
    {
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

                if (selectedobj.GetComponent<SpriteRenderer>().sprite == this.GetComponent<SpriteRenderer>().sprite)
                {
                    selectedobj.GetComponent<SpriteRenderer>().color = Color.white;
                    this.gameObject.SetActive(false);

                    if (AllGameManager.Instance.g.Length > 1)
                    {
                        selectedobj.GetComponent<CurectPosition>().isPlaced = true;
                    }
                }

                //selectedobj.GetComponent<CurectPosition>().isPlaced = true;
                if (HomeManager.instance.gameIndex == 0)
                {
                    this.gameObject.SetActive(false);

                    FeecTheAnimalsManager.Instance.CurrectEat();
                }
                else if (HomeManager.instance.gameIndex == 3)
                {


                    playerMovment.OnClickRun();
                }


            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Currect")
        {
            if (IscurrctObject)
            {
                IsSet = true;
                selectedobj = collision.gameObject;
                if (HomeManager.instance.gameIndex == 3)
                {
                    if (selectedobj.GetComponent<SpriteRenderer>().sprite != this.GetComponent<SpriteRenderer>().sprite)
                    {
                        transform.position = Currentposition;
                    }
                }


            }
            else
            {
                IsSet = false;
            }
        }
        else
        {

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Currect")
        {
            IsSet = false;
        }
    }
}
