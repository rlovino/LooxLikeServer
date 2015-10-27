using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace LooxLikeAPI.Services.UploaderAdapter
{
	public class AmazonClientAdapter : IUploaderAdapter
	{
		private readonly TransferUtility _transferUtility;
		public static readonly string BucketName = "looxlike-bucket";



		public AmazonClientAdapter()
		{
			_transferUtility = new TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.EUCentral1));
		}

		public string Upload(byte[] stream, string path)
		{
			MemoryStream memoryStream = new MemoryStream(stream);
			_transferUtility.Upload(memoryStream, BucketName, path);
			return "https://s3.eu-central-1.amazonaws.com/" + BucketName + "/" + path;
		}
	}
}