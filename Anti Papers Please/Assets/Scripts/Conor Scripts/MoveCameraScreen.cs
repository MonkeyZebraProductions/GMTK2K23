using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCameraScreen : MonoBehaviour
{
    public Image Cam;
    public Transform OffSetPos;
    public Canvas canvas;
    private Sprite sprite;
    public Image Photo;
    public RectTransform SpawnPoint;
    public RenderTexture Picture;

    // Update is called once per frame
    void Update()
    {
        var screenToWorldPosition = Camera.main.ScreenToWorldPoint(Cam.rectTransform.transform.position);
        transform.position = screenToWorldPosition + OffSetPos.position;
    }

    public void TakePicture()
    {
        Texture2D modelView = ToTexture2D(Picture);
        sprite = Sprite.Create(modelView, new Rect(0, 0, modelView.width, modelView.height), new Vector2(0.5f, 0.5f));
        sprite.name = modelView.name;
        Photo.sprite = sprite;

        Image createImage = Instantiate(Photo) as Image;
        createImage.transform.SetParent(canvas.transform, false);
        createImage.rectTransform.position = SpawnPoint.position;
    }

    public Texture2D ToTexture2D(RenderTexture rTex)
    {
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = rTex;

        Camera.current.Render();

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(rTex.width, rTex.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();

        RenderTexture.active = currentActiveRT;
        return tex;
    }
}
