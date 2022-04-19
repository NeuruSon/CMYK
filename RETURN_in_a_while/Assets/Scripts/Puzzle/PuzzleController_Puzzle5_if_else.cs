using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleController_Puzzle5_if_else : MonoBehaviour
{
    public TMP_Dropdown num_front_drd, num_back_drd, order_front_drd, order_back_drd;

    void Start()
    {

    }


    void Update()
    {
        isRight_void();
    }

    public bool isRight()
    {
        int nf_value = num_front_drd.value;
        int nb_value = num_back_drd.value;
        int of_value = order_front_drd.value;
        int ob_value = order_back_drd.value;

        if (nf_value > 0 && nb_value > 0 && Mathf.Abs(nf_value - nb_value) == 2
            && of_value > 0 && ob_value > 0 && of_value != ob_value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void isRight_void()
    {
        int nf_value = num_front_drd.value;
        int nb_value = num_back_drd.value;
        int of_value = order_front_drd.value;
        int ob_value = order_back_drd.value;

        if (nf_value > 0 && nb_value > 0 && Mathf.Abs(nf_value - nb_value) == 2
            && of_value > 0 && ob_value > 0 && of_value != ob_value)
        {
            Debug.Log("t");
            gameObject.tag = "true";
        }
        else
        {
            gameObject.tag = "PuzzleController";
        }
    }
}
