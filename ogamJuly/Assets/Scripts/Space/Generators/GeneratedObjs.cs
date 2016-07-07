﻿using UnityEngine;
using System.Collections;

public class GeneratedObjs : MonoBehaviour {

    [SerializeField]
    private bool GeneratingDone = false;

    void Start()
    {
        GeneratingDone = false;
    }

    public bool isGeneratingDone()
    {
        return GeneratingDone;
    }

    public void GeneratingIsDone()
    {
        GeneratingDone = true;
    }
}
