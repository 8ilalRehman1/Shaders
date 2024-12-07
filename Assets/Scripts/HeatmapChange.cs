using UnityEngine;

public class HeatMapChange: MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public Gradient colorGradient;
    private Texture2D heatmapTexture;
    private float[,] heightMap;

    void Start()
    {
        heatmapTexture = new Texture2D(width, height);
        GetComponent<Renderer>().material.mainTexture = heatmapTexture;
        heightMap = new float[width, height];
    }

    void Update()
    {
        UpdateHeatmap();
        ApplyHeatmap();
    }

    void UpdateHeatmap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heightMap[x, y] = Mathf.Sin(Time.time + (x + y) * 0.1f);
            }
        }
    }

    void ApplyHeatmap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float value = heightMap[x, y];
                Color color = colorGradient.Evaluate(value);
                heatmapTexture.SetPixel(x, y, color);
            }
        }
        heatmapTexture.Apply();
    }
}
