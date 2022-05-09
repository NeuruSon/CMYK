using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NameScriptManager : MonoBehaviour
{
    public Flowchart nameFC;

    // Start is called before the first frame update
    void Start()
    {
        nameFC.SetStringVariable("PlayerName", PlayData.playerName);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
