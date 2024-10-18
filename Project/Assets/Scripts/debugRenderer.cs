using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugRenderer : MonoBehaviour
{

    public List<MeshRenderer> debugRenderers;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.DoDebugRendering == false)
        {
            foreach (var ren in debugRenderers)
            {
                ren.enabled = false;
            }
        }
    }

}
