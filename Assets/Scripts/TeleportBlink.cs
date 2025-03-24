using UnityEngine;

public class TeleportBlink : MonoBehaviour
{
    public Material teleportMaterial;
    public float blinkSpeed = 1.5f; // Speed of fade in/out
    public float minAlpha = 0.2f;   // Minimum transparency
    public float maxAlpha = 1f;     // Maximum visibility

    private float targetAlpha;
    private bool fadingIn = true;

    void Start()
    {
        if (teleportMaterial == null)
            teleportMaterial = GetComponent<Renderer>().material;

        targetAlpha = maxAlpha;
    }

    void Update()
    {
        Color color = teleportMaterial.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * blinkSpeed);
        teleportMaterial.color = color;

        if (Mathf.Abs(color.a - targetAlpha) < 0.05f)
        {
            fadingIn = !fadingIn;
            targetAlpha = fadingIn ? maxAlpha : minAlpha;
        }
    }
}


