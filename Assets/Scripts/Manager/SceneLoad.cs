using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoad : BaseManager<SceneLoad>
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(string name,UnityAction action)
    {
        SceneManager.LoadScene(name);
        action.Invoke();
    }
}
