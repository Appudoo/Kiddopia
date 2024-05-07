using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class KiddopiaSongsManager : MonoBehaviour
{
    public GameObject videoplayer;
    public List<VideoClip> videoClips;
    public GameObject PausePanel;
    public GameObject waitingPanel;
    // Start is called before the first frame update
    void Start()
    {
        int a = PlayerPrefs.GetInt("Video");
        videoplayer.GetComponent<VideoPlayer>().clip = videoClips[a];
        waitingPanel.SetActive(false);
    }

    public void OnClickHome()
    {
        Destroy(HomeManager.instance.L);
        Ui_manager.Instance.EnableSinglePanels(StatePanel.KiddopiaSongs);
    }

    public void OnClickPause()
    {
        PausePanel.SetActive(true);
        videoplayer.GetComponent<VideoPlayer>().playbackSpeed = 0;
    }

    public void OnClickResume()
    {
        PausePanel.SetActive(false);
        videoplayer.GetComponent<VideoPlayer>().playbackSpeed = 1;
    }
}
