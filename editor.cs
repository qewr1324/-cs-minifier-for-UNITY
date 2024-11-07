using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(minifier))]
public class editor : Editor {

	// file name
	string name;

	// for inspector
	bool file;

	// GUI
	public override void OnInspectorGUI(){
		minifier _test = (minifier)target;
		EditorGUILayout.Space(); // sapce

		// label
		GUILayout.Box ("C# Minifier", GUILayout.ExpandWidth(true));
		EditorGUILayout.Space(); // sapce

		if(_test.check) {
			// ***  author of this project  ***
			EditorGUILayout.TextArea ("Success..!!\n\nwww.github.com/qewr1324\nwww.artstation.com/gurbesabzi\nauthor : Amirhussein Mohammadi Fard\n\nApache License\nVersion 2.0, January 2004\nhttp://www.apache.org/licenses/\n\n\nVersion 1.4.0");
			EditorGUILayout.Space(); // sapce
		}
		else{
			// note message
			EditorGUILayout.HelpBox ("\nﺪﯿﻨﮐ ﻑﺬﺣ #C ﺖﭙﯾﺮﮑﺳﺍ ﺭﺩ ﺍﺭ ﺎﻫ Comment ﻡﺎﻤﺗ ،ﻞﯾﺎﻓ ﻥﺩﺮﮐ ﺩﺭﺍﻭ ﺯﺍ ﻞﺒﻗ ًﺎﻔﻄﻟ\n\nPlease Delete All COMMENTs Text In The C# Script, Before You Import File\n", MessageType.Warning);
		}

		if (!_test.group) {
			GUILayout.BeginHorizontal (); // fix begin scale
			// import C# file
			if(GUILayout.Button("Import File\n*cs script*")){
				if (file) {
					if (name != null) _test.reader (); else EditorUtility.DisplayDialog ("Note", "یک نام برای فایل خود انتخاب کنید\n\nChoose a name for your file", "ok");
				} else _test.reader ();
			}
			// do minify process
			if(GUILayout.Button("Process\nFile")){
				_test.proccess ();
			}
			GUILayout.EndHorizontal (); // fix end scale
			EditorGUILayout.Space(); // sapce
		}
		else{
			// clear all variables and paths
			if(GUILayout.Button("Clear\n*Minifier*")){
				_test.refreshing ();
			}
		}
	}
}