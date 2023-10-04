using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public AudioSource backgroundMusicGameScene;
    public Transform imageTarget;
    public float maxRotation = 359f; //angle of rotation

    void Update()
    {
        if (backgroundMusicGameScene == null)
        {
            BackgroundMusic backgroundMusic = FindObjectOfType<BackgroundMusic>();

            if (backgroundMusic != null)
            {
                backgroundMusicGameScene = backgroundMusic.GetComponent<AudioSource>();
            }
        }

        if (backgroundMusicGameScene != null)
        {
            float rotationAngle = imageTarget.rotation.eulerAngles.y;
            float volumeLevel = Mathf.Clamp01(rotationAngle / maxRotation); //mapping of the values
            backgroundMusicGameScene.volume = volumeLevel;
            Debug.Log("Volume level: " + volumeLevel);
        }
    }
}
