using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogBehaviour : MonoBehaviour {

    public bool dialogActive = false;

    public Text dialogText;

    public Button resp1;
    public Button resp2;
    public Button resp3;

    public Button hide;

    public void ToggleVisability()
    {
        foreach(Transform t in transform)
        {
            if (!t.gameObject.name.Equals("Cancel"))
            {
                dialogActive = !t.gameObject.activeSelf;
                t.gameObject.SetActive(!t.gameObject.activeSelf);
            }
        }
    }

    void ToggleVisability(bool b)
    {
        dialogActive = b;
        foreach(RectTransform rt in transform)
        {
            rt.gameObject.SetActive(b);
        }
    }

    public void SetSettings(string dialogTextParam, int nrOfResponses, string[] responseTexts, GameObject origin)
    {
        resp1.gameObject.SetActive(false);
        resp2.gameObject.SetActive(false);
        resp3.gameObject.SetActive(false);

        if (!origin) { Debug.Log("source missing "); return; }
        if(nrOfResponses != responseTexts.Length) { Debug.Log("string[] failure length" + nrOfResponses + " != " + (responseTexts.Length)); return; }

       // DialogBase dialbase = origin.GetComponent<DialogBase>();

        dialogText.text = dialogTextParam;
        for(int i = 0; i < nrOfResponses; i++)
        {
            switch (i)
            {
                case 0: resp1.gameObject.SetActive(true);
                    Text resp1Text = resp1.GetComponentInChildren<Text>();
                    if (resp1Text){ resp1Text.text = responseTexts[i]; }
                    break;

                case 1: resp2.gameObject.SetActive(true);
                    Text resp2Text = resp2.GetComponentInChildren<Text>();
                    if (resp2Text) { resp2Text.text = responseTexts[i]; }
                    break;

                case 2: resp3.gameObject.SetActive(true);
                    Text resp3Text = resp3.GetComponentInChildren<Text>();
                    if (resp3Text) { resp3Text.text = responseTexts[i]; }
                    break;

                default: Debug.Log("Something went horribly wrong... "); break;
            }
        }
    }
}
