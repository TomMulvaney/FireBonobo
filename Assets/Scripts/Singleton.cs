using UnityEngine;
using System.Collections;

public class Singleton<T> : BonoBohaviour where T : Object 
{
    static T s_instance;

    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = (T)FindObjectOfType(typeof(T));
                return s_instance;
            }
            else
            {
                return s_instance;
            }
        }
    }
}
