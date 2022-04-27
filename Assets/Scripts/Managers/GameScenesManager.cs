using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : Singleton<GameScenesManager>
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
