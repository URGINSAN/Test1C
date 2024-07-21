using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] Windows;
    [Space]
    [SerializeField] private Text PlayerHealthText;

    public static UIController instance = null;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OpenWindow(string type)
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            if (Windows[i] != null)
                Windows[i].SetActive(false);
        }
        
        switch (type)
        {
            case "Start":
                if (Windows[0] != null)
                    Windows[0].SetActive(true);
                break;
            case "Game":
                if (Windows[1] != null)
                    Windows[1].SetActive(true);
                break;
            case "Win":
                if (Windows[2] != null)
                    Windows[2].SetActive(true);
                break;
            case "Lose":
                if (Windows[3] != null)
                    Windows[3].SetActive(true);
                break;
        }
    }

    public void SetPlayerHealth(int health)
    {
        PlayerHealthText.text = $"ÇÄÎÐÎÂÜÅ: {health}";
    }
}
