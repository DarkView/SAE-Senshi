using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Sprite openingScene;
    [SerializeField] private Sprite riu;
    [SerializeField] private Sprite akai;
    [SerializeField] private Sprite akumaPre;
    [SerializeField] private Sprite akumaMid;
    [SerializeField] private Sprite endScene;

    public void InitCutScene(int index)
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        LoadCutScene();
    }

    private void LoadCutScene()
    {
        switch (StoryManager.StoryIndex)
        {
            case 1:
                panel.GetComponent<Image>().sprite = openingScene;
                break;
            case 2:
            case 4:
                panel.GetComponent<Image>().sprite = riu;
                break;
            case 5:
            case 7:
                panel.GetComponent<Image>().sprite = akai;
                break;
            case 8:
                panel.GetComponent<Image>().sprite = akumaPre;
                break;
            case 10:
                panel.GetComponent<Image>().sprite = akumaMid;
                break;
            case 11:
                panel.GetComponent<Image>().sprite = endScene;
                break;
        }
    }
}