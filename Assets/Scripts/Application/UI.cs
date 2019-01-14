using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    [SerializeField]
	private GameObject input;

	private Vector2 basePos;
	private InputField field;
	private Text text;
	private float time = 0;

    private void Awake() {
        text = GetComponent<Text>();
        field = input.GetComponent<InputField>();
    }

    private void Start () {
		basePos = transform.localPosition;
		input.SetActive(false);
	}
	
	private void FixedUpdate () {
		time += Time.deltaTime;
		transform.localPosition = new Vector2(transform.localPosition.x, basePos.y + Mathf.Sin(Time.time * 5) * 4);
	
		if(time > 1.2f && text != null) {
			text.text = "Printer ready!";
			text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, 0, Time.deltaTime * 4));
			if(time > 2.5f) input.SetActive(true);
		}

		if(input.activeSelf && field.text.Length > 0 && Input.GetKeyDown(KeyCode.Return)) {
			Printer.Print(new PrintData(field.text));
			field.text = "";
		}
	}
}