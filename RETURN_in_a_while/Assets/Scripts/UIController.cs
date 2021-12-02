using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UI;
<<<<<<< Updated upstream
=======
    bool active = false;
>>>>>>> Stashed changes

    public void OpenUI()
    {
        UI.SetActive(true);
    }

    public void CloseUI()
    {
        UI.SetActive(false);
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
