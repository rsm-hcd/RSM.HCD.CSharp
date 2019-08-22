using AndcultureCode.CSharp.Extensions;
using Shouldly;
using System.Net;
using System.Net.Http;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Testing assertion extension methods related to HttpResponseMessage objects.
    /// Try your best to follow the 'Shouldly' API to maintain a common language in assertions.
    /// </summary>
    public static class HttpResponseMessageMatcherExtensions
    {
        #region Status Codes

        /// <summary>
        /// General purpose extension to shouldly's ShouldBe around status code assertion
        /// </summary>
        /// <param name="response"></param>
        /// <param name="statusCode"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBe(this HttpResponseMessage response, HttpStatusCode statusCode, bool withContent = true)
        {
            var responseBody = response.Content?.ReadAsStringAsync().Result;
            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                responseBody = responseBody.AsIndentedJson();
            }

            response.StatusCode.ShouldBe(statusCode, $"Expected status code to be '{statusCode}', but was '{response.StatusCode}' instead.\n\nAPI Response:\n {responseBody}\n\n");

            if (withContent)
            {
                response.Content.ShouldNotBeNull();
            }
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 400 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeABadRequest(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.BadRequest, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 409 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeAConflict(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.Conflict, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 201 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeCreated(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.Created, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 403 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent"></param>
        public static void ShouldBeForbidden(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.Forbidden, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 500 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeInternalServerError(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.InternalServerError, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 200 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeOk(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.OK, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 404
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldNotBeFound(this HttpResponseMessage response, bool withContent = false)
        {
            response.ShouldBe(HttpStatusCode.NotFound, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 204 (with or without content)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeNoContent(this HttpResponseMessage response, bool withContent = true)
        {
            response.ShouldBe(HttpStatusCode.NoContent, withContent);
        }

        /// <summary>
        /// Simplified approach to asserting if the HTTP status code was 401
        /// </summary>
        /// <param name="response"></param>
        /// <param name="withContent">Should we also assert that a content body was supplied</param>
        public static void ShouldBeUnauthorized(this HttpResponseMessage response, bool withContent = false)
        {
            response.ShouldBe(HttpStatusCode.Unauthorized, withContent);
        }

        #endregion Status Codes
    }
}

