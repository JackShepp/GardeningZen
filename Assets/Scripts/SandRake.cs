using UnityEngine;

public class SandRake : MonoBehaviour
{
    public Material sandMaterial; // The material with the displacement shader
    public float rakeStrength = 0.05f; // The amount of displacement caused by the rake
    public float rakeRadius = 0.1f; // The radius of the rake's interaction

    private void Update()
    {
        // Get the rake position
        Vector3 rakePosition = transform.position;

        // Use raycast or collision detection to determine if the rake is over the sand
        RaycastHit hit;
        if (Physics.Raycast(rakePosition, Vector3.down, out hit, 1.0f))
        {
            if (hit.collider.CompareTag("Sand"))
            {
                // Get the UV position of the hit point on the sand surface
                Vector2 uv = hit.textureCoord;

                // Update the height map at that UV point
                UpdateHeightMap(uv);
            }
        }
    }

    void UpdateHeightMap(Vector2 uv)
    {
        // You would need to access the heightmap texture of the material
        // In this case, using a RenderTexture or Texture2D to modify the heightmap.

        Texture2D heightMap = sandMaterial.GetTexture("_HeightMap") as Texture2D;

        if (heightMap != null)
        {
            // Get the pixel at the UV position (adjust UV coordinates to texture size)
            Vector2Int pixelPos = new Vector2Int((int)(uv.x * heightMap.width), (int)(uv.y * heightMap.height));

            // Get the current height value and increase it based on the rake's strength
            float currentHeight = heightMap.GetPixel(pixelPos.x, pixelPos.y).r;
            currentHeight += rakeStrength;

            // Clamp the value to make sure it stays within the range [0, 1]
            currentHeight = Mathf.Clamp01(currentHeight);

            // Set the new height value back into the texture
            heightMap.SetPixel(pixelPos.x, pixelPos.y, new Color(currentHeight, currentHeight, currentHeight));

            // Apply changes to the texture
            heightMap.Apply();
        }
    }
}
