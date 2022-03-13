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
        anim.ResetTrigger("Unselected");
        anim.SetTrigger("Selected");
        if (OnSelected != null) {
            OnSelected.Invoke();
        }
    }

    public void OnUnselectedButton() {
        anim.SetTrigger("Unselected");
        anim.ResetTrigger("Selected");
        if (OnUnselected != null)
            OnUnselected.Invoke();
    }

    public void OnPressedButton() {
        anim.ResetTrigger("Unselected");
        anim.SetTrigger("Pressed");
        if (OnPressed != null)
            OnPressed.Invoke();
    }
}
