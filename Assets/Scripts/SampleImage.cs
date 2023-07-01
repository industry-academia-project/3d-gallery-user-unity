using UnityEngine;
using UnityEngine.EventSystems;

public class SampleImage : MonoBehaviour, IPointerClickHandler
{

    public Texture texture;

    public void OnPointerClick(PointerEventData eventData)
    {
        SetImage();
    }

    private void SetImage()
    {
        var curator = Curator.INSTANCE;
        if (curator == null) return;
        curator.FocusingFrame.texture = texture;
    }
}