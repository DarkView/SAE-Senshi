using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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
        switch (index)
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
