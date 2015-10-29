using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IslandCreator))]
public class IslandCreatorInspector : Editor {

	private IslandCreator creator;

	private void OnEnable () {
		creator = target as IslandCreator;
		Undo.undoRedoPerformed += RefreshCreator;
	}

	private void OnDisable () {
		Undo.undoRedoPerformed -= RefreshCreator;
	}

	private void RefreshCreator () {
		if (Application.isPlaying) {
//			creator.FillTexture();
		}
	}

	public override void OnInspectorGUI () {
		EditorGUI.BeginChangeCheck ();
		DrawDefaultInspector ();
		if (EditorGUI.EndChangeCheck ()) {
			RefreshCreator();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
