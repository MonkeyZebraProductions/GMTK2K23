using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Person : MonoBehaviour
{
    public TMP_Text Speech;
    public Canvas SpeechBubble;

    public void Speak(string dialogue)
    {
        SpeechBubble.enabled = true;
        Speech.text = dialogue;
    }
}
