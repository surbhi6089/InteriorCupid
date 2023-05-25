using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    private Sprite soundOnImg;
    [SerializeField] private Sprite soundOffImg;
    [SerializeField] private Button btn;
    private bool isOn = true;

    public AudioClip calm1, calm2, calm3, jazz1, jazz2, jazz3;

    public AudioSource src;

    void Start()
    {
        soundOnImg = btn.image.sprite;
    }
    public void calmButton1()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm1;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
    public void calmButton2()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm2;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
    public void calmButton3()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm3;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
    public void jazzButton1()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm3;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
    public void jazzButton2()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm3;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
    public void jazzButton3()
    {
        if (isOn)
        {
            btn.image.sprite = soundOffImg;
            isOn = false;
            src.clip = calm3;
            src.Play();
        }
        else
        {
            btn.image.sprite = soundOnImg;
            isOn = true;
            src.Pause();
        }
    }
}
