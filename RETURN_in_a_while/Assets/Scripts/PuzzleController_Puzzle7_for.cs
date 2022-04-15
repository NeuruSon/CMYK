using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;
using Button = UnityEngine.UI.Button;

public class PuzzleController_Puzzle7_for : MonoBehaviour
{
    public GameObject t_repeatCount; //횟수_tmp
    GameObject clickedBtn;
    public Image img_tempBridge;

    void Start()
    {
        if (gameObject.tag == "PuzzleController")
        {

        }
    }

    void Update()
    {
        
    }

    public void clicked()
    {
        Button btn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        clickedBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        SpriteState sprite = new SpriteState();
        sprite = btn.spriteState;

    }
}
