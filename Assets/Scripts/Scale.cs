using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float scaleFactor;

    public void Apply() {
       Vector2 scale = gameObject.transform.localScale;
       scale *= new Vector2(scaleFactor, scaleFactor);
       gameObject.transform.localScale = scale;
    }
}
