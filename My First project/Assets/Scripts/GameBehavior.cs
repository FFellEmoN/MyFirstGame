using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager
{
    //учебное поле класса
    private string _state;

    private int _itemsCollected = 0;
    private int _playerHP = 1;
    private string labelText;
    public const int _maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;



    private void Start()
    {
        Initialize();

        if (_itemsCollected == 0)
        {
            labelText = "Collect all " + _maxItems + " items and win your freedom";
        }
    }
    //Учебный интерфейс
    public void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);
    }

    void StopGame(string Text)
    {
        if(Text == "You win")
        {
        showWinScreen = true;
        }
        else
        {
            showLossScreen = true;
        }

        Time.timeScale = 0f;
    }
    //учебная публичная переменная
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public int Items
    {
        get
        {
            return _itemsCollected;
        }

        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= _maxItems)
            {
                labelText = "You win";

                StopGame(labelText);
            }
            else
            {
                
                if (_itemsCollected == 1) 
                {
                     labelText = "You find only " + _itemsCollected + " item you should stil find " + (_maxItems - _itemsCollected);
                }
                else
                {
                     labelText = "You find only " + _itemsCollected + " items you should stil find " + (_maxItems - _itemsCollected);
                }
               
            }
        }
    }

    public int HP
    {
        get 
        { return _playerHP;  }

        set
        {
            _playerHP = value;
            if(_playerHP <= 0)
            {
                labelText = "You want another life with that ?";
                StopGame(labelText);
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25),
            "HP: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25),
            "Items Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50,
            300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "YOU WIN!")) 
            {
                Utilities.RestartLevel();
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
}
