using UnityEngine;
using System.Collections;

/// <summary>
/// To add a dialog and options, use CreateDialog in Start, override responses then use base.responseX() at the end of every override. 
/// Then make anything happen in the response.
/// </summary>
public class DialogBase : MonoBehaviour {

    public float DialogTriggerDistance = 10;
    protected DialogBehaviour DialBeh;
    protected GameObject player;
    private string dialogText = "";
    private int numberOfResponses = 0;
    private string[] responseTexts;

    void InitiateDialog()
    {
        if (!player) { player = GameObject.FindGameObjectWithTag("Player"); }
        if (!DialBeh) { DialBeh = GameObject.Find("UIDialog").GetComponent<DialogBehaviour>(); }
    }

    public void DialogUpdate()
    {
        if (player)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < DialogTriggerDistance)
            {
                TriggerDialog();
            }
        }
    }

    void Update()
    {
        DialogUpdate();
        if (Input.GetKeyDown(KeyCode.I))
        {
            TriggerDialog();
        }
    }

    virtual public void CreateDialog(string dialogTextParam, string[] responseTextsParam)
    {
        if(responseTextsParam.Length <= 0) { return; }
        dialogText = dialogTextParam;
        numberOfResponses = responseTextsParam.Length;
        responseTexts = responseTextsParam;
    }

    virtual public void TriggerDialog()
    {
        if (!DialBeh) { InitiateDialog(); }
        if (DialBeh) { DialBeh.SetSettings(dialogText, responseTexts, gameObject); }
    }

    virtual public void Response1()
    {
        PressDone();
    }

    virtual public void Response2()
    {
        PressDone();
    }

    virtual public void Response3()
    {
        PressDone();
    }

    protected void PressDone()
    {
        if (DialBeh) { DialBeh.dialogActive = false;  DialBeh.ToggleVisability(false); }
    }
}

