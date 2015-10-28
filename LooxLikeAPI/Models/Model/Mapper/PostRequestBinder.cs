using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using LooxLikeAPI.Models.JSONModel.Request;

namespace LooxLikeAPI.Models.Model.Mapper
{
	public class PostRequestBinder : IModelBinder
	{
		public PostRequestBinder()
		{
			
		}

		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{
			if (actionContext.Request.Content.IsMimeMultipartContent())
			{

				var parts = actionContext.Request.Content.ReadAsMultipartAsync().Result;
				foreach (var part in parts.Contents)
				{
					var headers = part.Headers;
					if (headers.ContentType.MediaType == "image/jpeg")
					{
						
					}



				}



			}
		}
	}
}