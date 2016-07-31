using UnityEngine;
using System.Collections;

public class DialogBase : MonoBehaviour {

    public float DialogTriggerDistance = 10;
    protected DialogBehaviour DialBeh;
    protected GameObject player;
    public string dialogText = "";
    public int numberOfResponses = 1;
    public string[] responseTexts;

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

    virtual public void CreateDialog(string dialogTextParam, int nrOfResponses, string[] responseTextsParam)
    {
        if(nrOfResponses <= 0) { Debug.Log("<< number of responses is less or equal to 0 >> "); return; }

        dialogText = dialogTextParam;
        numberOfResponses = nrOfResponses;
        responseTexts = responseTextsParam;
        if (DialBeh)
        {
            DialBeh.SetSettings(dialogText, numberOfResponses, responseTexts, gameObject);
        }
        else
        {
            Debug.Log("Dialog Behaviour missing from " + gameObject.name);
        }

    }

    virtual public void TriggerDialog()
    {
        Debug.Log("Triggered Dialog needs to be overwritten for " + gameObject.name);
    }

    virtual public void Response1()
    {
        Debug.Log("Response 1 needs to be overwritten for " + gameObject.name);
    }

    virtual public void Response2()
    {
        Debug.Log("Response 2 needs to be overwritten for " + gameObject.name);
    }

    virtual public void Response3()
    {
        Debug.Log("Response 3 needs to be overwritten for " + gameObject.name);
    }
}

