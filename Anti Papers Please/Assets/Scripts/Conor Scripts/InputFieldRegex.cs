using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using TMPro;

using UnityEngine;

public class InputFieldRegex : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldToTest;

    public bool isValid = false;
    public string RegexString;

    private void Update()
    {
        // string datePattern = @"[0-9]+/[0-9]+/[0-9]+"; //Use @"PATTERNHERE" because the @ makes sure it uses "literal" characters and doesnt think / and \ are exiting and entering
        string datePattern = @"(^0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/(\d{2}$)"; //Use @"PATTERNHERE" because the @ makes sure it uses "literal" characters and doesnt think / and \ are exiting and entering

        isValid = Regex.Matches(inputFieldToTest.text, datePattern).Count > 0;
    }
}
