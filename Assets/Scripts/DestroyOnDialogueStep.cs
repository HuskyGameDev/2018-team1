using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDialogueStep : MonoBehaviour
{
    void Update()
    {
        if(Sinput.GetButtonDown("Submit")){
            Destroy(gameObject);
        }
    }
}
