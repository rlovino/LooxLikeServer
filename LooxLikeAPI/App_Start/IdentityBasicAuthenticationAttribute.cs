﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;


namespace LooxLikeAPI.App_Start
{
    public class IdentityBasicAuthenticationAttribute : Attribute, IAuthenticationFilter
    {

        public System.Threading.Tasks.Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;
           
            var validation = Task.FromResult(Validate(request, authorization, context));
            var authentication = validation.ContinueWith(
                tupleTask =>
                {
                    if (tupleTask.Result != null)
                    {
                        var tuple = tupleTask.Result;
                        var username = tuple.Item2.Item1;
                        var password = tuple.Item2.Item2;

                        var principal = Authenticate(username, password, cancellationToken);
                        if (principal == null)
                        {
                            context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
                        }
                        else
                        {
                            context.Principal = principal;
                        }
                    }

                }
                );

            return authentication;
        }


        public System.Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Basic");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }


        public bool AllowMultiple
        {
            get { throw new NotImplementedException(); }
        }

        private IPrincipal Authenticate(string userName, string password, System.Threading.CancellationToken cancellationToken)
        {
            if (registeredUser.Contains(Tuple.Create(userName, password)))
            {
                var identity = new GenericIdentity(userName);
                var principal = new GenericPrincipal(identity, new string[] { "user" });
                return principal;
            }

            return null;
        }


        private Tuple<string, string> ExtractUserNameAndPassword(string authParameter)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(authParameter));
            int seperatorIndex = usernamePassword.IndexOf(':');

            var username = usernamePassword.Substring(0, seperatorIndex);
            var password = usernamePassword.Substring(seperatorIndex + 1);

            return Tuple.Create(username, password);

        }


        private Tuple<HttpAuthenticationContext, Tuple<string, string>> Validate(System.Net.Http.HttpRequestMessage request, System.Net.Http.Headers.AuthenticationHeaderValue authorization, HttpAuthenticationContext context)
        {
            if (authorization == null || authorization.Scheme != "Basic")
                return null;

            if (String.IsNullOrEmpty(authorization.Parameter))
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
            Tuple<string, string> userNameAndPasword = ExtractUserNameAndPassword(authorization.Parameter);
            if (userNameAndPasword == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
            }

            return Tuple.Create(context, userNameAndPasword);
        }
      

        private List<Tuple<String, String>> registeredUser = new List<Tuple<string, string>> {
            Tuple.Create("alessadro","password"),
            Tuple.Create("daniele","password"),
            Tuple.Create("raffaele","password")
        };


    }
}