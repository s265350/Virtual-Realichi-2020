﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexFlip : MonoBehaviour
{
    private Animator _agendaAnimator;

    public Texture[] _totalPages;

    public List<Texture> _discoveredPagesList;

    public Texture[] _discoveredPages;

    public Texture _backgroundTexture;

    //public List<int> _discoveredIndex;

    public int _currentPage = 0;
    private Codex codex;


    void Start()
    {
        codex = GetComponent<Codex>();
        _agendaAnimator = GetComponent<Animator>();
        //UpdateDiscovered(_discoveredIndex);
    }
    void OnEnable()
    {
        if(codex) UpdateDiscovered(codex._discoveredIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            FlipLToR();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            FlipRToL();
    }

    public void FlipRToL()
    {
        if (_agendaAnimator == null || _currentPage == _discoveredPagesList.Count)
            return;

        _agendaAnimator.SetBool(name: "FlipRToL", true);

    }

    public void setNextRightBG()
    {
        if (codex._discoveredIndex.Count == _currentPage + 1) setTexture("Right_BG", _backgroundTexture);
        else setTexture("Right_BG", _discoveredPagesList[_currentPage + 1]);
    }

    private void setTexture(string child, Texture texture)
    {
        //TODO cambiare anche normal map se si fa il testo inciso
        gameObject
                .transform.Find(child)
                .gameObject.GetComponent<Renderer>()
                .material.mainTexture = texture;
    }

    public void FlipLToR()
    {
        if (_agendaAnimator == null || _currentPage == 0)
            return;

        _agendaAnimator.SetBool(name: "FlipLToR", true);

    }

    public void ResetRPage()
    {

        _agendaAnimator.SetBool(name: "FlipRToL", false);

        setTexture("Left", _discoveredPagesList[_currentPage]);

        _currentPage++;

        if (_currentPage == _discoveredPagesList.Count) setTexture("Right", _backgroundTexture);
        else setTexture("Right", _discoveredPagesList[_currentPage]);

    }

    public void setNextLeftBG()
    {
        setTexture("Left_BG", _discoveredPagesList[_currentPage]);
    }

    public void setPreviousLeftBG()
    {
        if (_currentPage - 1 == 0) setTexture("Left_BG", _backgroundTexture);
        else setTexture("Left_BG", _discoveredPagesList[_currentPage - 2]);
    }
    public void setPreviousRightBG()
    {
        setTexture("Right_BG", _discoveredPagesList[_currentPage - 1]);
    }

    public void ResetLPage()
    {

        _agendaAnimator.SetBool(name: "FlipLToR", false);

        setTexture("Right", _discoveredPagesList[_currentPage - 1]);

        _currentPage--;

        if (_currentPage > 0) setTexture("Left", _discoveredPagesList[_currentPage - 1]);
        else setTexture("Left", _discoveredPagesList[0]);
    }

    public void UpdateDiscovered(List<int> indexes)
    {

        _discoveredPagesList.Clear();

        for (int i = 0; i < indexes.Count; i++)
        {
            _discoveredPagesList.Add(_totalPages[indexes[i]]);
        }

        setTexture("Left_BG", _backgroundTexture);
        setTexture("Right", _discoveredPagesList[0]);
        setTexture("Right_BG", _discoveredPagesList[0]);
    }

    public void addDiscoveryId(int _discoveryId)
    {
        codex._discoveredIndex.Add(_discoveryId);
        codex._discoveredIndex.Sort();
        UpdateDiscovered(codex._discoveredIndex);
    }
}
