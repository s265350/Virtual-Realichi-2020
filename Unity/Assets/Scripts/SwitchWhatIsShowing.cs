using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWhatIsShowing : MonoBehaviour
{

    private GameObject codex;
    private GameObject mappa;
    private GameObject obiettivi;
    private byte indexAgenda;
    // Start is called before the first frame update
    void Start()
    {
        Codex cod = GameObject.FindObjectOfType<Codex>();
        codex = cod.gameObject;
        Mappa map = GameObject.FindObjectOfType<Mappa>();
        mappa = map.gameObject;
        Obiettivi obs = GameObject.FindObjectOfType<Obiettivi>();
        obiettivi = obs.gameObject;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (indexAgenda == 0) indexAgenda = 2; else indexAgenda--;
            Show();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (indexAgenda == 2) indexAgenda = 0; else indexAgenda++;
            Show();
        }
    }

    private void Show()
    {

        if (indexAgenda == (int)agendaType.codex)
        {
            mappa.GetComponent<Mappa>().enabled = false;
            mappa.GetComponent<Renderer>().enabled = false;
            obiettivi.GetComponent<Renderer>().enabled = false;
            codex.GetComponent<CodexFlip>().enabled = true;
            for (int i = 0; i < 6; i++)
            {
                codex.transform.GetChild(i).GetComponent<Renderer>().enabled = true;
            }
        }
        else if (indexAgenda == (int)agendaType.mappa)
        {
            mappa.GetComponent<Mappa>().enabled = true;
            mappa.GetComponent<MeshRenderer>().enabled = true;
            obiettivi.GetComponent<Renderer>().enabled = false;
            codex.GetComponent<CodexFlip>().enabled = false;
            for (int i = 0; i < 6; i++)
            {
                codex.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
            mappa.GetComponent<Mappa>().enabled = false;
            mappa.GetComponent<Renderer>().enabled = false;
            obiettivi.GetComponent<Renderer>().enabled = true;
            codex.GetComponent<CodexFlip>().enabled = false;
            for (int i = 0; i < 6; i++)
            {
                codex.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void OnDisable()
    {
        codex.GetComponent<CodexFlip>().enabled = false;
        for (int i = 0; i < 6; i++)
        {
            codex.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
        }
        mappa.GetComponent<Mappa>().enabled = false;
        mappa.GetComponent<Renderer>().enabled = false;
        obiettivi.GetComponent<Renderer>().enabled = false;
    }
}