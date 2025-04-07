using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelObject : MonoBehaviour
{
    public string nextLevel;

    public void MovetoNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
