using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
	
	public TMP_Text playerNameText;
	LobbyManager lobbyManager;

	private IEnumerator Start()
	{
		playerNameText = GetComponentInChildren<TMP_Text>();

		lobbyManager = FindObjectOfType<LobbyManager>();


        if (IsServer)
		{
			while (NetworkManager.Singleton.ConnectedClients.Count != LobbyManager.joinnedLobby.Players.Count)
			{
				yield return new WaitForSeconds(1);
			}
			yield return new WaitForSeconds(1);
			for (int i = 0; i < NetworkManager.Singleton.ConnectedClients.Count; i++)
			{
				NetworkManager.Singleton.ConnectedClients[(ulong)i].PlayerObject.GetComponentInChildren<PlayerName>()
					.SetPlayerNameClientRpc(LobbyManager.joinnedLobby.Players[i].Data["name"].Value);
			}

		}
	}



	[ServerRpc]
	public void SetPlayerNameServerRpc()
	{		
		//SetPlayerNameClientRpc(lobbyManager.playerNameInput.text);
	}

	[ClientRpc]
	public void SetPlayerNameClientRpc(string playerName)
	{
		playerNameText.text = playerName;
	}
}
