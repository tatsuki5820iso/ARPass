using System;
using System.Collections.Generic;
using System.Linq;
using UniRx.Async;
using UnityEngine.Networking;

namespace ARPass.Core.Http
{
	public static class APIUtils
	{
		public static string AddGetParameters(this string uri, Dictionary<string, string> parameters)
		{
			if (parameters == null) return uri;
			var queries = String.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
			return $"{uri}?{queries}";
		}

		public static async UniTask SendRequest(this UnityWebRequest request)
		{
			await request.SendWebRequest();
		}

		public static APIResult ToAPIResult(this UnityWebRequest request)
		{
			var status = (APIStatus) request.responseCode;
			if (status >= APIStatus.BadRequest) throw new APIException(status, request.downloadHandler.text);
			return new APIResult(status, request.downloadHandler.text);
		}
	}
}