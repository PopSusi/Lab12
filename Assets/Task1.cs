using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    List<string> Letters = new List<string>();
    List<string> Names = new List<string>();
    List<string> LoggedIn = new List<string>();
    Queue<string> Queue = new Queue<string>();
    int total;

    void Awake()
    {
        InitializeNames();
        total = (int)Random.Range(5, 27);

    }
    private void Start()
    {
        StartCoroutine("Build");
    }
    IEnumerator Build()
    {
        Queue.Enqueue(BuildName());
        total--;
        yield return new WaitForSeconds(.2f);
        if (total != 0)
        {
            yield return new WaitForSeconds(.2f);
            StartCoroutine("Build");
        }
        //string nextPerson = Queue.Peek();
        yield return new WaitForSeconds(.3f);
        LoggedIn.Add(Queue.Dequeue());
        Debug.Log($"{LoggedIn[LoggedIn.Count- 1]} has logged in");
        if (Queue.TryPeek(out string nextPerson))
        {
            Debug.Log($"{nextPerson} is trying to login and added to the login queue");
        }

    }
    public string BuildName() => Names[Random.Range(0, 25)] + " " + Letters[Random.Range(0, 25)];
    private void InitializeNames()
    {
        Letters.Add("A");
        Letters.Add("B");
        Letters.Add("C");
        Letters.Add("D");
        Letters.Add("E");
        Letters.Add("F");
        Letters.Add("G");
        Letters.Add("H");
        Letters.Add("I");
        Letters.Add("J");
        Letters.Add("K");
        Letters.Add("L");
        Letters.Add("M");
        Letters.Add("N");
        Letters.Add("O");
        Letters.Add("P");
        Letters.Add("Q");
        Letters.Add("R");
        Letters.Add("S");
        Letters.Add("T");
        Letters.Add("U");
        Letters.Add("V");
        Letters.Add("W");
        Letters.Add("X");
        Letters.Add("Y");
        Letters.Add("Z");
        Names.Add("Carlos");
        Names.Add("David");
        Names.Add("Susi");
        Names.Add("April");
        Names.Add("Dan");
        Names.Add("Christine");
        Names.Add("Leo");
        Names.Add("Gianna");
        Names.Add("Isabelle");
        Names.Add("Isabella");
        Names.Add("Braeden");
        Names.Add("Jaiden");
        Names.Add("Aiden");
        Names.Add("Kevin");
        Names.Add("Lenny");
        Names.Add("Ciara");
        Names.Add("Bear");
        Names.Add("Carter");
        Names.Add("Emory");
        Names.Add("Landon");
        Names.Add("Camryn");
        Names.Add("Zachary");
        Names.Add("Jeremy");
        Names.Add("Millie");
        Names.Add("Jarvis");
        Names.Add("Connor");
    }
}
