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
    public TMP_Text TimerText, MoneyText;

    private int money;

    private float timer;
    public bool IsGearOut;

    private bool copIsPresent;
    private bool clientIsPresent;

    private GameObject currentClient;
    GameObject currentCar;

    GameObject currentCop;

    public Canvas GameCanvas, OverCanvas;

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

        MoneyText.text = "$" + money;

        if(timer>=TimeLimit)
        {
            EndGame();
        }


        if(!clientIsPresent)
        {
            clientIsPresent = true;
            SpawnClient();
        }

    }

    public IEnumerator EndGameWithWait()
    {
        yield return new WaitForSeconds(3);
        EndGame();
    }

    public void EndGame()
    {
        OverCanvas.enabled = true;
        GameCanvas.enabled = false;
    }

    private void SpawnClient()
    {
        currentClient = Instantiate(people[UnityEngine.Random.Range(0,people.Count)]);
        int chosenCar = UnityEngine.Random.Range(0,cars.Count);
        currentClient.GetComponent<Client>().car = chosenCar;
        currentCar = Instantiate(cars[chosenCar]);
    }

    public void FinishClient()
    {
        if(PapersManager.instance.ValidatePapers())
        {
            money+=10;
        }
        Destroy(currentClient);
        Destroy(currentCar);
        PapersManager.instance.DestroyPapers();
        clientIsPresent = false;
    }

    IEnumerator CopCoroutine()
    {
        while(gameIsRunning)
        {
            yield return new WaitForSeconds(20);
            if(UnityEngine.Random.value > 0.5 && !copIsPresent)
            {
                copIsPresent = true;
                SpawnCop();
                yield return new WaitForSeconds(5);
                Destroy(currentCop);
            }
        }
        
    }

    public void SpawnCop()
    {
        currentCop = Instantiate(cop);
    }
}
