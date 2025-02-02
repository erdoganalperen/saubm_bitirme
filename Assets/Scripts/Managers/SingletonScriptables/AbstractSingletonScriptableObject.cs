﻿using UnityEngine;

public abstract class AbstractSingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.Log("AbstractSingletonScriptableObject -> Instance -> results length is 0 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.Log("AbstractSingletonScriptableObject -> Instance -> results length is greater than 1 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                _instance = results[0];
            }
            return _instance;
        }
    }
    public virtual void Initialize() { }
}
