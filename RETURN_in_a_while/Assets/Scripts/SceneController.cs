using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void toTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void toTestScene() //작업용 임시
    {
        SceneManager.LoadScene("Test");
    }

    public void toPuzzleScene()
    {
        SceneManager.LoadScene("Puzzle");
    }

    public void toTempMapScene()
    {
        SceneManager.LoadScene("MainTest");
    }

    public void toTowerScene()
    {
        SceneManager.LoadScene("InTower");
    }
}
