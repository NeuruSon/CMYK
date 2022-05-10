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

    public void toPuzzleYScene()
    {
        SceneManager.LoadScene("Puzzle_Y");
    }

    public void toPuzzleCScene()
    {
        SceneManager.LoadScene("Puzzle_C");
    }

    public void toPuzzleMScene()
    {
        SceneManager.LoadScene("Puzzle_M");
    }

    public void toPuzzleKScene()
    {
        SceneManager.LoadScene("Puzzle_K");
    }

    public void toTempMapScene()
    {
        SceneManager.LoadScene("MainTest");
    }

    public void toTowerYScene() //
    {
        SceneManager.LoadScene("InTower_Y");
    }

    public void toTowerCScene() // 
    {
        SceneManager.LoadScene("InTower_C");
    }

    public void toTowerMScene() //
    {
        SceneManager.LoadScene("InTower_M");
    }

    public void toGotoCScene() //
    {
        SceneManager.LoadScene("gotoC");
    }

    public void toCaveScene() //
    {
        SceneManager.LoadScene("Cave");
    }

    public void toShowPuzzleScene()
    {
        SceneManager.LoadScene("showPuzzle");
    }

    public void toScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public string getThisSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}