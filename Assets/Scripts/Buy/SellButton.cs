using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    public static SellButton _button;
    public static SellButton Button { get { return _button; } }

    public bool isSell;

    private void Awake()
    {
        _button = this;
    }

    public void Sell()
    {
        isSell = true;
    }
    public void back()
    {
        isSell = false;
    }
}
