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
        character.GetObject();
    }
    public override void Highlight(GameObject caller)
    {
        character.HighlightObject();
    }

    public override void OriginalColor(GameObject caller)
    {
        character.ReturnOriginalColor();
    }

}
