using UnityEngine;
using UnityEditor;
using System.IO;

public class minifier : MonoBehaviour 
{
	// C# file.
	TextAsset file;

	// text input processing.
	string process;
	string stream;

	// for checking whitespace in script.
	byte space;

	// file address.
	internal string path;
	internal bool check , group;

	// read the cs file.
	internal void reader ()
	{
		try{
			// refreshing data.
			check = false;
			group = false;
			refresh ();

			// opens File Explorer and gets the file path.
			path = EditorUtility.OpenFilePanel ("Choose Your *Cs File(.cs)", "", "cs");
		}
		catch{
			// to show the dialog page in unity.
			if (path == "") EditorUtility.DisplayDialog ("Note", "You must select a C# file", "ok");
		}
	}
	// process the cs file.
	internal void proccess()
	{
		try{
			// get object file as a TestAsset type.
			file = (TextAsset)AssetDatabase.LoadAssetAtPath("File://" + path.Replace("\\", "/").Trim(), typeof(TextAsset)) as TextAsset;

			// the entire script reads the line and sets it to string.
			string stream = File.ReadAllText (path);

			// remove extra lines in script.
			stream.Replace("\n", "");

			// clears whitespace and preserves the script.
			for (int b = 0; b < stream.Length; b++) {
				switch (stream [b])
				{
				case ' ': if(stream [b + 1] != ' ') process += stream [b]; break;
				case '.': process += stream [b]; break;
				case '=': process += stream [b]; break;
				case '+': process += stream [b]; break;
				case ':': process += stream [b]; break;
				case '[': process += stream [b]; break;
				case ']': process += stream [b]; break;
				case '(': process += stream [b]; break;
				case ')': process += stream [b]; break;
				case '{': process += stream [b]; break;
				case '}': process += stream [b]; break;
				case '<': process += stream [b]; break;
				case '>': process += stream [b]; break;
				case ';': process += stream [b]; break;
				case 'a': process += stream [b]; break;
				case 'b': process += stream [b]; break;
				case 'c': process += stream [b]; break;
				case 'd': process += stream [b]; break;
				case 'e': process += stream [b]; break;
				case 'f': process += stream [b]; break;
				case 'g': process += stream [b]; break;
				case 'h': process += stream [b]; break;
				case 'i': process += stream [b]; break;
				case 'j': process += stream [b]; break;
				case 'k': process += stream [b]; break;
				case 'l': process += stream [b]; break;
				case 'm': process += stream [b]; break;
				case 'n': process += stream [b]; break;
				case 'o': process += stream [b]; break;
				case 'p': process += stream [b]; break;
				case 'q': process += stream [b]; break;
				case 'r': process += stream [b]; break;
				case 's': process += stream [b]; break;
				case 't': process += stream [b]; break;
				case 'u': process += stream [b]; break;
				case 'v': process += stream [b]; break;
				case 'w': process += stream [b]; break;
				case 'x': process += stream [b]; break;
				case 'y': process += stream [b]; break;
				case 'z': process += stream [b]; break;
				case 'A': process += stream [b]; break;
				case 'B': process += stream [b]; break;
				case 'C': process += stream [b]; break;
				case 'D': process += stream [b]; break;
				case 'E': process += stream [b]; break;
				case 'F': process += stream [b]; break;
				case 'G': process += stream [b]; break;
				case 'H': process += stream [b]; break;
				case 'I': process += stream [b]; break;
				case 'J': process += stream [b]; break;
				case 'K': process += stream [b]; break;
				case 'L': process += stream [b]; break;
				case 'M': process += stream [b]; break;
				case 'N': process += stream [b]; break;
				case 'O': process += stream [b]; break;
				case 'P': process += stream [b]; break;
				case 'Q': process += stream [b]; break;
				case 'R': process += stream [b]; break;
				case 'S': process += stream [b]; break;
				case 'T': process += stream [b]; break;
				case 'U': process += stream [b]; break;
				case 'V': process += stream [b]; break;
				case 'W': process += stream [b]; break;
				case 'X': process += stream [b]; break;
				case 'Y': process += stream [b]; break;
				case 'Z': process += stream [b]; break;
				case '-': process += stream [b]; break;
				case '_': process += stream [b]; break;
				case '!': process += stream [b]; break;
				case '$': process += stream [b]; break;
				case '?': process += stream [b]; break;
				case '&': process += stream [b]; break;
				case '*': process += stream [b]; break;
				case '^': process += stream [b]; break;
				case '~': process += stream [b]; break;
				case '\'': process += stream [b]; break;
				case '"': process += stream [b]; break;
				case '|': process += stream [b]; break;
				case ',': process += stream [b]; break;
				case '@': process += stream [b]; break;
				case '%': process += stream [b]; break;
				case '\\': process += stream [b]; break;
				case '/': process += stream [b]; break;
				case '0': process += stream [b]; break;
				case '1': process += stream [b]; break;
				case '2': process += stream [b]; break;
				case '3': process += stream [b]; break;
				case '4': process += stream [b]; break;
				case '5': process += stream [b]; break;
				case '6': process += stream [b]; break;
				case '7': process += stream [b]; break;
				case '8': process += stream [b]; break;
				case '9': process += stream [b]; break;
				}
			}
			// creates an empty C# script in the directory.
			File.Create(path).Close();

			// and then it refreshes unity to find the created file.
			AssetDatabase.Refresh ();

			// sets all processed scripts in the generated file.
			File.AppendAllText (path, process);

			// and then it refreshes Unity to find the C# script.
			AssetDatabase.Refresh ();

			// // refreshing data.
			check = true;
			group = true;
			refresh ();
		}
		catch{
			// to show the dialog page in unity.
			if(path == "") EditorUtility.DisplayDialog ("Warning", "\nابتدا یک فایل متنی اتخاب کنید\n\nChoose a file for process\n", "ok");
			else EditorUtility.DisplayDialog ("Note", "\nیک چیزی اشتباه است\n\nSomething is wrong\n", "ok");
		}
	}

	// refreshing method.
	private void refresh()
	{
		// refreshing variables.
		process = "";
		stream = "";
		file = null;
		path = "";
		space = 1;
	}
	// refresh this package.
	internal void refreshing()
	{
		// // refreshing data.
		check = false;
		group = false;
		refresh ();
	}
}