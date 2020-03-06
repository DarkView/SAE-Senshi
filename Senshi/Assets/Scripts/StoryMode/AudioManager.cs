using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// manages background audio in fight scene
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// background music for fight with riu
    /// </summary>
    [SerializeField] private GameObject musicRiu;
    /// <summary>
    /// background music for fight with akai
    /// </summary>
    [SerializeField] private GameObject musicAkai;
    /// <summary>
    /// background music for fight with akuma
    /// </summary>
    [SerializeField] private GameObject musicAkuma;

    /// <summary>
    /// checks if we are in story mode or not
    /// </summary>
    private void Awake()
    {
        if (StoryManager.isStoryMode)
            SetMusicStory();
        else
            SetMusicSinglePlayer();
        
    }

    /// <summary>
    /// sets the background audio in fightScene depending on Story Stage
    /// </summary>
    public void SetMusicStory()
    {
        switch (CutSceneManager.StoryIndex)
        {
            case 3:
                musicRiu.SetActive(true);
                break;
            case 6:
                musicAkai.SetActive(true);
                break;
            case 9:
            case 12:
                musicAkuma.SetActive(true);
                break;
        }
    }

    public void SetMusicSinglePlayer()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                musicRiu.SetActive(true);
                break;
            case 2:
                musicAkai.SetActive(true);
                break;
            case 3:
                musicAkuma.SetActive(true);
                break;
        }   
    }
}
