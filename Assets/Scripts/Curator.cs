using UnityEngine;

public class Curator : MonoBehaviour
{
    public static Curator INSTANCE;

    public Frame FocusingFrame = null;

    private void Awake()
    {
        // Singleton
        if (INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(this);
    }

}