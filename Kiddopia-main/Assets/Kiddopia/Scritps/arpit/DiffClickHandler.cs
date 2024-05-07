using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("DiffManager.instance.TotalBtn[DiffManager.instance.DiffCount]  " + DiffManager.instance.gameObject.name);
        DiffManager.instance.TotalBtn[DiffManager.instance.DiffCount].GetComponent<Image>().color = Color.white;
        DiffManager.instance.DiffCount++;
        DiffManager.instance.Check();
        this.gameObject.SetActive(false);
    }
}
