using UnityEngine;
using System.Collections;

public class AudioToggle : MonoBehaviour
{
	private bool isMute;

	public bool IsMute {
		get {
			return isMute;
		}
		set {
			isMute = value;
		}
	}

	public void AudioIsMute ()
	{
		isMute = !isMute;
	}
}
