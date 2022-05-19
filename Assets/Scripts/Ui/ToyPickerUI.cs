using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyPickerUI : MonoBehaviour
{
    public HorizontalLayoutGroup container;
    
    public List<Toy> toys;
    public ToyButton button;

    private void Awake()
    {
        toys.ForEach(g => AddButton(g));
    }

    private void AddButton(Toy toy)
    {
        var tab = Instantiate(button, container.transform) as ToyButton;
        tab.ToySetup(toy);
    }
}
