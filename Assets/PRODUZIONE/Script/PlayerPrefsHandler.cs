﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsHandler
{
	public const string PLAYER_KEY_S = "playerKey";
	public const string MUTE_MUSICHE_INT = "muteMusiche";
	public const string MUTE_EFFETTI_INT = "muteEffetti";
	public const string VOLUME_F = "volume";
	public const string RECORD_PERS_INT = "recordPersonale";
	public const string NUM_PARTITE_INT = "numPartiteTotali";
	public const string MONETE_INT = "monete";
	public const string PERSONAGGIO_ATTUALE_S = "personaggioAttuale";
	public const string REMOVE_ADS = "rimuoviAds";
	public const string VERSION_S = "versioneString";
	public const string DEVICE_S = "nomeDevice";




	public void RestorePreferences()
	{
		SetMutedMusica(GetIsMutedMusica());
		SetMutedEffetti(GetIsMutedEffetti());
	}

	public void InitializePreferences()
	{
		SetMutedEffetti(false);
		SetMutedMusica(false);
	}

    public void CreateFirstTimePref()
    {
		InitializePreferences();
		SetPlayerKey(GetPlayerKey());
		SetMonete(0);
		SetRecordPersonale(0);
		SetPersonaggioAttuale("The Loocka");
		SetGiocatoreByNome("The Loocka");
		SetNumPartiteTotali(0);
		SetRemoveAds(false);
	}

    public bool isFirstTime()
    {
		if (GetPlayerKey().Length > 0)
		{
			return false;
		}
		else
		{
			return true;
		}


    }

	public bool isSamsung()
	{
		if (GetDeviceName().Equals("Samsung"))
		{
			return true;
		}
		else
		{
			return false;
		}


	}

	public string GetVersionName()
	{
		return PlayerPrefs.GetString(VERSION_S, "");
	}

	public void SetVersionName(string val)
	{
		PlayerPrefs.SetString(VERSION_S, val);
	}

	public string GetDeviceName()
	{
		return PlayerPrefs.GetString(DEVICE_S, "");
	}

	public void SetDeviceName(string val)
	{
		if (val.Contains("Galaxy") || val.Contains("Samsung") || val.Contains("Unknown"))
		{
			PlayerPrefs.SetString(DEVICE_S, "Samsung");
		}
	}

	public string GetPlayerKey()
	{
		return PlayerPrefs.GetString(PLAYER_KEY_S,"");
	}

	public void SetPlayerKey(string val)
	{
		PlayerPrefs.SetString(PLAYER_KEY_S, val);
	}

    public bool GetGiocatoreByNome(string s)
    {
		string nome = PlayerPrefs.GetString(s);
		if (nome.Equals(s)) return true;
		else return false;
    }

    public void SetGiocatoreByNome(string s)
    {
		PlayerPrefs.SetString(s, s);
    }

	public int GetMonete()
	{
		return PlayerPrefs.GetInt(MONETE_INT);
	}

	public void SetMonete(int val)
	{
		PlayerPrefs.SetInt(MONETE_INT, val);
	}

	public int GetRecordPersonale()
    {
		return PlayerPrefs.GetInt(RECORD_PERS_INT);
    }

	public void SetRecordPersonale(int val)
	{
		PlayerPrefs.SetInt(RECORD_PERS_INT, val);
	}

	public int GetNumPartiteTotali()
	{
		return PlayerPrefs.GetInt(NUM_PARTITE_INT);
	}

	public void SetNumPartiteTotali(int val)
	{
		PlayerPrefs.SetInt(NUM_PARTITE_INT, val);
	}

	public void SetMutedEffetti(bool muted)
	{
		PlayerPrefs.SetInt(MUTE_EFFETTI_INT, muted ? 1 : 0);

		// Pausing the AudioListener will disable all sounds.
		//AudioListener.pause = muted;
	}

	public bool GetIsMutedMusica()
	{
		// If the value of the MUTE_INT key is 1 then sound is muted, otherwise it is not muted.
		// The default value of the MUTE_INT key is 0 (i.e. not muted).
		return PlayerPrefs.GetInt(MUTE_MUSICHE_INT, 0) == 1;
	}

	public void SetMutedMusica(bool muted)
	{
		PlayerPrefs.SetInt(MUTE_MUSICHE_INT, muted ? 1 : 0);

		// Pausing the AudioListener will disable all sounds.
		//AudioListener.pause = muted;
	}

	public bool GetIsMutedEffetti()
	{
		// If the value of the MUTE_INT key is 1 then sound is muted, otherwise it is not muted.
		// The default value of the MUTE_INT key is 0 (i.e. not muted).
		return PlayerPrefs.GetInt(MUTE_EFFETTI_INT, 0) == 1;
	}

	public void SetVolume(float volume)
	{
		// Prevent values less than 0 and greater than 1 from
		// being stored in the PlayerPrefs (AudioListener.volume expects a value between 0 and 1).
		volume = Mathf.Clamp(volume, 0, 1);
		PlayerPrefs.SetFloat(VOLUME_F, volume);
		AudioListener.volume = volume;
	}

	public float GetVolume()
	{
		return Mathf.Clamp(PlayerPrefs.GetFloat(VOLUME_F, 1), 0, 1);
	}

	public string GetPersonaggioAttuale()
	{
		return PlayerPrefs.GetString(PERSONAGGIO_ATTUALE_S);
	}

	public void SetPersonaggioAttuale(string val)
	{
		PlayerPrefs.SetString(PERSONAGGIO_ATTUALE_S, val);
	}

	public bool GetRemoveAds()
	{
		// If the value of the MUTE_INT key is 1 then sound is muted, otherwise it is not muted.
		// The default value of the MUTE_INT key is 0 (i.e. not muted).
		return PlayerPrefs.GetInt(REMOVE_ADS, 0) == 1;
	}

	public void SetRemoveAds(bool muted)
	{
		PlayerPrefs.SetInt(REMOVE_ADS, muted ? 1 : 0);

		// Pausing the AudioListener will disable all sounds.
		//AudioListener.pause = muted;
	}

}
