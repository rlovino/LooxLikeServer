using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LooxLikeAPI.Services.UploaderAdapter
{
	public interface IUploaderAdapter
	{
		string Upload(byte[] stream, string path);
	}
}
