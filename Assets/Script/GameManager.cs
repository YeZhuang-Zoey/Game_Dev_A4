using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    AudioSource backgroundAudio, soundEffectAudio;

    public PacmanController pacmanController;
    public GameObject cherry;

    public AudioClip normalClip, scaredClip, deadClip;
    public AudioClip eatPellet, pacWalk, wallCollide;

    void Start()
    {
        backgroundAudio = gameObject.GetComponent<AudioSource>();
        soundEffectAudio = pacmanController.GetComponent<AudioSource>();
        createCherry();
    }

    //BGM
    public void deadState()
    {
        if (!isDeadState())
        {
            backgroundAudio.clip = deadClip;
            backgroundAudio.Play();
        }
    }
    public void scaredState()
    {
        backgroundAudio.clip = scaredClip;
        backgroundAudio.Play();
    }
    public void normalState()
    {
        backgroundAudio.clip = normalClip;
        backgroundAudio.Play();
    }

    public bool isDeadState()
    {
        return backgroundAudio.clip == deadClip;
    }


    // Sound Effect
    public void pauseAudio()
    {
        soundEffectAudio.Stop();
    }

    public void hitWallAudio()
    {
        soundEffectAudio.clip = wallCollide;
        soundEffectAudio.volume = 1f;
        soundEffectAudio.loop = false;
        soundEffectAudio.Play();
    }

    public void eatPelletAudio()
    {
        CancelInvoke();
        soundEffectAudio.loop = false;
        soundEffectAudio.clip = eatPellet;
        soundEffectAudio.Play();
        Invoke("resetAudio", .5f); //reset
    }
    public void noWall() //resey
    {
        soundEffectAudio.volume = 0.15f;
        soundEffectAudio.loop = true;
        Invoke("resetAudio", soundEffectAudio.clip.length); //reset

    }
    void resetAudio() //reset
    {
        soundEffectAudio.loop = true;
        soundEffectAudio.clip = pacWalk;
        soundEffectAudio.Play();
    }

    void createCherry()
    {
        GameObject cherryInstance = Instantiate(cherry, new Vector2(-15, (new System.Random()).Next(-10, 10)), Quaternion.identity);
    }

    public void LoadStartScene()
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync(0);
    }
}

