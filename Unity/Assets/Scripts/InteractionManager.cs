﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private RawImage _eButton;
    private Interattivo _pointingInteractable;
    private CharacterController _fpsController;
    private Vector3 _rayOrigin;


    void Start()
    {
        _eButton.enabled = false;
        if(_fpsCameraT == null)
        {
            _fpsCameraT = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
        _fpsController = GetComponent<CharacterController>();
        _interactionDistance = 3f;
    }

    void Update()
    {
        // Creo ogni volta il raggio, dalla posizione della camera a una distanza pari a un raggio lungo la forward. 
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;
        CheckInteraction();
        UpdateUITarget();
    }

    //Creo un raggio a partire dall'origine. Devo sapere se l'oggetto che sto puntando è interagibile e con esso faccio partire un tipo di interazione.
    private void CheckInteraction()
    {
        if (_pointingInteractable != null)
        {
            _eButton.enabled = false;
            _pointingInteractable = null;
        }

        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interattivo>(); //recupero un oggetto di tipo interactable.
            if (_pointingInteractable) //se non è nullo, invoco la funzione interact
            {
                UpdateUITarget();
                if (Input.GetKeyDown(KeyCode.E))
                    _pointingInteractable.Interact(gameObject); //Uso classi di base per definire comportamenti nelle implementazioni di classe. Interactable è una classe astratta. parto da una classe interactable e creo una lista infinita di oggetti interactable in cui faccio override e nella funzione specifica definisco il comportamento che l'oggetto deve avere. Tutti gli oggetti hanno uno script a cui è associato un comportamento, ereditano dalla classe Interact.
            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
        }
    }
    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _eButton.enabled = true;
        else
            _eButton.enabled = false;
    }

}
