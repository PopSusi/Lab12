using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Names;
using Unity.VisualScripting;

public class Task2 : MonoBehaviour
{
    Task1 library;
    string[] randNames = new string[15];
    List<string> duplicates = new List<string>();
    HashSet<string> seen = new HashSet<string>();
    // Start is called before the first frame update
    private void Awake()
    {
        library= GetComponent<Task1>();
    }
    void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            randNames[i] = library.BuildName();  
        }
        foreach (string name in randNames)
        {
            if (!seen.Contains(name))
            {
                seen.Add(name);
            }
            else
            {
                duplicates.Add(name);
            }
        }
        BuildOutput();
    }
    private void BuildOutput()
    {
        string made = "";
        string dupped = "";
        for (int i = 0; i < 15; i++)
        {
            made = made + randNames[i] + ", ";
        }
        for (int i = 0; i < duplicates.Count; i++)
        {
            dupped = dupped + duplicates[i] + ", ";
        }
        Debug.Log($"Created the name array: {made}");
        Debug.Log($"The array has duplicate names: {dupped}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
