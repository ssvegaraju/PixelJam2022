using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MenuButton : MonoBehaviour
{
    private Animator anim;

    public UnityEvent OnSelected, OnUnselected, OnPressed;

    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void OnSelectedButton() {
        anim.SetBool("Selected", true);
        if (OnSelected != null) {
            OnSelected.Invoke();
        }
    }

    public void OnUnselectedButton() {
        anim.SetBool("Selected", false);
        if (OnUnselected != null)
            OnUnselected.Invoke();
    }

    public void OnPressedButton() {
        anim.SetTrigger("Pressed");
        if (OnPressed != null)
            OnPressed.Invoke();
    }

    public void OnPointerOver() {
        MainMenuManager.instance.OnMouseChangeSelection(this);
    }

    public void OnPointerClick() {
        MainMenuManager.instance.onMouseConfirmSelection(this);
    }
}
