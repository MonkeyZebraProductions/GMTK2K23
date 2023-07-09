using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public float TimeLimit;
    public GameObject Gear;
    public TMP_Text TimerText;

    private float timer;
    public bool IsGearOut;

    public static GameManager instance { get; private set;}

    private void Awake()
    {
        if(instance !=null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsGearOut = Gear.activeSelf;
        timer += Time.deltaTime;
        TimerText.text = "Time: " + TimeSpan.FromSeconds(timer).ToString("mm\\:ss");

        if(timer>=TimeLimit)
        {
            Debug.Log("It's Over Bro");
        }

    }
}
