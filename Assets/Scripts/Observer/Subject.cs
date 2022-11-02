using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<Observer> observers = new List<Observer>();

    public void Ping()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnPing();
        }
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }
}
