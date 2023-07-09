using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Mono.Cecil.Cil;

using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public int currentPageNumber;
    public GameObject currentPage;
    public GameObject[] pages;

    public Button pageBackButton;
    public Button pageForwardButton;

    private void Start() {
        GoToPage(0);
    }

    public void GoToPage(int changeTo) {
        if (currentPage) {
            currentPage.SetActive(false);    
        }

        currentPageNumber = changeTo;
        currentPage = pages[changeTo];
        
        currentPage.SetActive(true);

        pageBackButton.interactable = currentPageNumber > 0;
        pageForwardButton.interactable = currentPageNumber < pages.Length - 1;
    }
    
    public void ChangePage(int changeBy) {
        currentPageNumber += changeBy;
        currentPageNumber = Mathf.Clamp(currentPageNumber, 0, pages.Length-1);
        GoToPage(currentPageNumber);
    }

    public void ChangePage(string countryName) {
        for (int i = 0; i < pages.Length; i++) {
            if (pages[i].name.Contains(countryName)) {
                GoToPage(i);
                return;
            }
        }
        
        Debug.Log("<color=red>Could not find country: " + countryName + "!</color>");
    }
}
