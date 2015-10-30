using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using LooxLikeAPI.Models.JSONModel.Request;
using LooxLikeAPI.Services.UploaderAdapter;

namespace LooxLikeAPI.Services
{
	public class PhotoUploaderService: IPhotoUploaderService
	{
		private readonly IUploaderAdapter _uploaderAdapter;

		public PhotoUploaderService(IUploaderAdapter uploaderAdapter)
		{
			_uploaderAdapter = uploaderAdapter;
		}


		public string UploadPhoto(PostRequest postRequest, string username)
		{
			var md5 = MD5.Create();
			var hash = md5.ComputeHash(postRequest.Image);
			var md5String = new StringBuilder();

			foreach (var t in hash)
				md5String.Append(t.ToString("x2"));
			
			var path = username + "/" + postRequest.C10 + "_" + md5String + postRequest.ImageExtension.ToLower();
			return _uploaderAdapter.Upload(postRequest.Image, path);
		}
	}
}