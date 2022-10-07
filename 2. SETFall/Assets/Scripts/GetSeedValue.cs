using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 

public class GetSeedValue : MonoBehaviour
{
    public GameObject seedObject;
    public static int seedValue;
    public void SeedSet()
    {
        string seedString = seedObject.GetComponent<TMP_InputField>().text;
        if (int.TryParse(seedString, out int n) == true)
        {
            seedValue = int.Parse(seedString);       
        }
    }
}
