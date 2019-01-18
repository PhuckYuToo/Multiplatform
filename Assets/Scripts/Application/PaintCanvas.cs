using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PaintCanvas : MonoBehaviour {

    [SerializeField]
    private GameObject prefabBrush;
    [SerializeField]
    private RenderTexture renTex;
    [SerializeField]
    private float brushSize = 0.03f;
    [SerializeField]
    private int moveLimit = 1000;
    [SerializeField]
    private LayerMask layer;

    private List<GameObject> moves = new List<GameObject>();

    private void Update () {
        if (Input.GetMouseButton(0) && moves.Count < moveLimit) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Canvas") || hit.collider.CompareTag("Brush")) {
                    GameObject brush = Instantiate(prefabBrush, hit.point + Vector3.up * 0.05f,
                                                                hit.transform.rotation, transform);
                    brush.transform.localScale = Vector3.one * brushSize;
                    moves.Add(brush);
                }
            }
        }
        else if (Input.GetMouseButton(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Collider[] cols = Physics.OverlapSphere(hit.point, brushSize * 1.5f, layer);
                foreach(Collider c in cols) {
                    moves.Remove(c.gameObject);
                    Destroy(c.gameObject);
                }
            }
        }
        
	}

    public void ChangeBrushSize(UnityEngine.UI.Slider slider) {
        brushSize = slider.value;
    }

    public void Save() {
        StartCoroutine(DoSave());
    }

    private IEnumerator DoSave() {
        yield return null;
        RenderTexture.active = renTex;
        Texture2D tex = new Texture2D(renTex.height, renTex.width);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();

        /* DISCLAIMER: BMP Conversion doesn't work quite work yet! 
         * This is just WIP code that's not part of the system */
        byte[] data = tex.EncodeToPNG();
        StringBuilder hex = new StringBuilder(data.Length * 2);
        foreach (byte b in data) hex.AppendFormat("0x" + "{0:x2}" + ",", b);
        File.WriteAllBytes(Application.dataPath + "/bmp.png", data);
    }
}