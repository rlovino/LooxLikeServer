﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using LooxLikeAPI.Models.JSONModel.Request;
using System.Threading.Tasks;
using System.Threading;

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


				var multipartContent = Task.Factory.StartNew(() => actionContext.Request.Content.ReadAsMultipartAsync().Result,
					CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);

				var taskContents = multipartContent.ContinueWith(multipart => {
					                                                              return multipart.Result.Contents;
				});
				var postRequestTask = taskContents.ContinueWith<PostRequest>(contents =>
				{
					try
					{
						var postRequest = new PostRequest();
						var contentDescription =
							contents.Result.Single(content => content.Headers.ContentDisposition.Name.Equals("\"description\""));
						var contentPhoto = contents.Result.Single(content => content.Headers.ContentDisposition.Name.Equals("\"photo\""));
						var contentc10 = contents.Result.Single(content => content.Headers.ContentDisposition.Name.Equals("\"c10\""));

						var tasks = new[]
						{
							contentDescription.ReadAsStringAsync()
								.ContinueWith(descriptionTask => { postRequest.Description = descriptionTask.Result; }),
							contentPhoto.ReadAsByteArrayAsync().ContinueWith(photoTask => { postRequest.Image = photoTask.Result; }),
							contentc10.ReadAsStringAsync().ContinueWith(c10Task => { postRequest.C10 = c10Task.Result; })
						};

						Task.WhenAll(tasks);

						return postRequest;
					}
					catch (Exception e)
					{
						return null;
					}
				});

				return postRequestTask.ContinueWith(pTask =>
				{
					if (pTask.Result != null)
					{
						bindingContext.Model = pTask.Result;
						return true;
					}
					else
					{
						bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
						return false;
					}
				}).Result;

			}
			else
				return false;

		}

	}
}
