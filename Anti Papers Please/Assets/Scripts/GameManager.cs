using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}
    private bool gameIsRunning;
    public float TimeLimit;
    public GameObject Gear;
    public TMP_Text TimerText;

    private float timer;
    public bool IsGearOut;

    private bool copIsPresent;


    //Things to spawn.
    [SerializeField]
    private List<GameObject> cars = new List<GameObject>();
    [SerializeField]
    private List<GameObject> people = new List<GameObject>();

    [SerializeField]
    private GameObject cop;

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

        gameIsRunning = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CopCoroutine());
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

    IEnumerator CopCoroutine()
    {
        while(gameIsRunning)
        {
            yield return new WaitForSeconds(20);
            if(UnityEngine.Random.value > 0.5 && !copIsPresent)
            {
                copIsPresent = true;
                //Spawn cop
            }
        }
        
    }
}
