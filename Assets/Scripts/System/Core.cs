using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : Singleton<Core>
{
    [SerializeField] private UiSystem ui;
    [SerializeField] private Data data;
    [SerializeField] private InputHandler inp;

    public static UiSystem UI => Instance.ui;
    public static Data Data => Instance.data;
    public static InputHandler Binds => Instance.inp;
}
