using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraChange : MonoBehaviour
{
    [Header("Camaras")]
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;


    private void Start()
    {
        //Inicia en primera persona
        FirstCam.SetActive(true);
        ThirdCam.SetActive(false);
    }

      private void OnTriggerEnter(Collider other)
      {
        //Detecta la layer de rest y cambia a 3era persona
        if (other.gameObject.layer == LayerMask.NameToLayer("Rest"))
        {
            //aqui cambia
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }

      }
    //Detecta si no salimos de la layer y vuelve a 1era persona
    private void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.layer == LayerMask.NameToLayer("Rest"))
        {
            //vuelve
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);

        }
    }
}


    /*IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }*/

