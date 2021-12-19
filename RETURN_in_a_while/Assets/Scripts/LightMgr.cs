using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMgr : MonoBehaviour
{
    static GameObject sphere;
    static GameObject lightParticle;
    static Material[] mat;
   

    private void Start()
    {
        sphere = GameObject.Find("Sphere");
        lightParticle = GameObject.Find("light");
        lightParticle.SetActive(false);
        mat = sphere.GetComponent<MeshRenderer>().sharedMaterials;
        

    }

    public static void lightOn()
    {
        mat[0] = mat[1];
        sphere.GetComponent<MeshRenderer>().sharedMaterials = mat;
        lightParticle.SetActive(true);
    }

}
