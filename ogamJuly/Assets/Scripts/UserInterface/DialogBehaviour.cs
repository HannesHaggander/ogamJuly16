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

    private int nrOfResponses = 0;

    public void ToggleVisability()
    {
        foreach(Transform t in transform)
        {
            if (!t.gameObject.name.Equals("Cancel"))
            {
                t.gameObject.SetActive(!t.gameObject.activeSelf);
            }
        }
    }

    public void ToggleVisability(bool b)
    {
        foreach(RectTransform rt in transform)
        {
            rt.gameObject.SetActive(b);
        }
    }

    public void SetSettings(string dialogTextParam, string[] responseTexts, GameObject origin)
    {
        if (dialogActive) { return; }
        dialogActive = true;
        resp1.gameObject.SetActive(false);
        resp1.onClick.RemoveAllListeners();

        resp2.gameObject.SetActive(false);
        resp2.onClick.RemoveAllListeners();

        resp3.gameObject.SetActive(false);
        resp3.onClick.RemoveAllListeners();

        if (!origin) { Debug.Log("source missing "); return; }
        if(responseTexts.Length > 3) { Debug.Log("string[] failure length" + (responseTexts.Length)); return; }
        nrOfResponses = responseTexts.Length;

        DialogBase dialbase = origin.GetComponent<DialogBase>();

        dialogText.text = dialogTextParam;
        for(int i = 0; i < nrOfResponses; i++)
        {
            switch (i)
            {
                case 0: resp1.gameObject.SetActive(true);
                    Text resp1Text = resp1.GetComponentInChildren<Text>();
                    if (resp1Text)
                    {
                        resp1Text.text = responseTexts[i];
                        resp1.onClick.AddListener(() => dialbase.Response1());
                    }
                    break;

                case 1: resp2.gameObject.SetActive(true);
                    Text resp2Text = resp2.GetComponentInChildren<Text>();
                    if (resp2Text)
                    {
                        resp2Text.text = responseTexts[i];
                        resp2.onClick.AddListener(() => dialbase.Response2());
                    }
                    break;

                case 2: resp3.gameObject.SetActive(true);
                    Text resp3Text = resp3.GetComponentInChildren<Text>();
                    if (resp3Text)
                    {
                        resp3Text.text = responseTexts[i];
                        resp3.onClick.AddListener(() => dialbase.Response3());
                    }
                    break;

                default: Debug.Log("Something went horribly wrong... "); break;
            }
        }

        ToggleVisability(true);
    }
}
