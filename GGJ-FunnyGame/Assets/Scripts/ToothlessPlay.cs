using UnityEngine;
using UnityEngine.Video;
using UnityEditor;

public class ToothlessPlay : MonoBehaviour
{
    [SerializeField] private VideoPlayer vPlayer;
    [SerializeField] private GameObject toothlessPanel;

    private void Start()
    {
        toothlessPanel.SetActive(false);
    }
    public void playVid()
    {
        toothlessPanel.SetActive(true);
        if (vPlayer.isPlaying == false)
            vPlayer.Play();
    }

    public void stopVid()
    {
        vPlayer.Stop();
        toothlessPanel.SetActive(false);
    }
}
