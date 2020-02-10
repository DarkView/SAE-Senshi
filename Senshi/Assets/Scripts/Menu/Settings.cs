using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// SettingsButtons
/// by Zayarmoe
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] private Slider audio;

    private void Update()
    {
        ChangeAudio();
    }

    private void ChangeAudio()
    {
        AudioListener.volume = audio.value;
    }

    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
    }
}
