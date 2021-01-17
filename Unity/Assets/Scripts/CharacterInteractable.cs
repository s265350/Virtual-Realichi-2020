using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterInteractable : Interattivo
{
    private Character character;

    void Start()
    {
        character = gameObject.GetComponent<Character>();
    }
    public override void Interact(GameObject caller)
    {
        character.Talk(caller);
    }

}
