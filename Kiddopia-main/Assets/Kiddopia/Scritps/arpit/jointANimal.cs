using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointANimal : MonoBehaviour
{
    public List<GameObject> levels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickFeedTheAnimal(int index)
    {
        PlayerPrefs.SetInt("jointTheAnimal", index);
        Debug.Log(index);
        GameObject L = Instantiate(levels[index]);
        HomeManager.instance.L = L;
        Ui_manager.Instance.DisableAllPanel();
    }
}
