using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Frame : Focusable
{
    public RawImage image;

    public Texture texture
    {
        get => image.texture;
        set { image.texture = value; }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        var curator = Curator.INSTANCE;
        if (curator == null) return;

        curator.FocusingFrame = this;
    }
}
