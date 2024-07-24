using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChineseNameSplitter : MonoBehaviour
{
    public static (string lastName, string firstName) SplitName(string fullName)
    {
        if (string.IsNullOrEmpty(fullName) || fullName.Length < 2)
        {
            throw new ArgumentException("The full name must be at least 2 characters long.");
        }

        // Assume the first character is the last name and the rest is the first name
        string lastName = fullName.Substring(0, 1);
        string firstName = fullName.Substring(1);

        return (lastName, firstName);
    }
}
