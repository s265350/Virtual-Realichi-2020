using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

enum agendaType { mappa = 0, codex = 1, obiettivi = 2 };
public class ShowAgenda : MonoBehaviour
{
    private Animator _animator;
    private bool _show = false;
    void Start()
    {       
        _animator = GetComponent<Animator>();
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MoveAgenda();
            
        }
    }

    public void MoveAgenda()
    {
        if (_animator == null) return;
        _show = !_show;
        _animator.SetBool("show", _show);
    }

    public void disablePlayerMovement()
    {
        GameObject.FindObjectOfType<FirstPersonController>().GetComponent<FirstPersonController>().enabled = false;
        GetComponent<SwitchWhatIsShowing>().enabled = true;
    }
    public void enablePlayerMovement()
    {
        GameObject.FindObjectOfType<FirstPersonController>().GetComponent<FirstPersonController>().enabled = true;
        GetComponent<SwitchWhatIsShowing>().enabled = false;
    }

}
