using UnityEngine;
using System.Collections;

public class Dialogtestingscript : DialogBase {

    public string tstStr = "This is a test";


    void Start()
    {
        string[] tstarr = new string[] { "Tst1", "tst2" };
        CreateDialog(tstStr, tstarr);
    }

    public override void Response1()
    {
        Debug.Log("user pressed resp 1");
        base.Response1();
    }

    public override void Response2()
    {
        Debug.Log("Use pressed resp 2");
        base.Response2();
    }
}
