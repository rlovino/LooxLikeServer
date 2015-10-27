using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LooxLikeAPI.Models.JSONModel.Request;

namespace LooxLikeAPI.Services
{
	public interface IPhotoUploaderService
	{
		string UploadPhoto(PostRequest postRequest, string username);
	}
}
