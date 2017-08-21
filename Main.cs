using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main  {

    private static UIManager uiInstance;

    public static UIManager UiInstance
    {
        get
        {
            if (uiInstance == null)
            {
                uiInstance = new UIManager();
            }
            return uiInstance;
        }
    }
}
