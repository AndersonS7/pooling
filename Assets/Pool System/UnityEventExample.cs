using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UnityEventExample : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTesteEvent;

    //exemplo de delegate
    //delegate que será chamado quando o elemento da lista for ativo
    public delegate void OnEnableElement();
    public static OnEnableElement onEnable;

    //delegate que será chamado quando o elemento da lista for desativado
    public delegate void OnDisableElement();
    public static OnDisableElement onDisable;

    private void Start()
    {
        OnTesteEvent?.Invoke();
    }
}
