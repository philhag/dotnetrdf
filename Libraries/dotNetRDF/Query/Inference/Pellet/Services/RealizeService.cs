/*
// <copyright>
// dotNetRDF is free and open source software licensed under the MIT License
// -------------------------------------------------------------------------
// 
// Copyright (c) 2009-2020 dotNetRDF Project (http://dotnetrdf.org/)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
*/

using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VDS.RDF.Query.Inference.Pellet.Services
{
    /// <summary>
    /// Represents the Realize Service provided by a Pellet Server.
    /// </summary>
    public class RealizeService : PelletService
    {
        /// <summary>
        /// Creates a new Realize Service.
        /// </summary>
        /// <param name="name">Service Name.</param>
        /// <param name="obj">JSON Object.</param>
        internal RealizeService(String name, JObject obj)
            : base(name, obj) { }

        /// <summary>
        /// Gets the Graph which comprises the class hierarchy and individuals of those classes.
        /// </summary>
        /// <returns></returns>
        public IGraph Realize()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Endpoint.Uri);
            request.Method = Endpoint.HttpMethods.First();
            request.Accept = MimeTypesHelper.CustomHttpAcceptHeader(MimeTypes, MimeTypesHelper.SupportedRdfMimeTypes);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                    Graph g = new Graph();
                    parser.Load(g, new StreamReader(response.GetResponseStream()));

                    response.Close();
                    return g;
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                }

                throw new RdfReasoningException("A HTTP error occurred while communicating with the Pellet Server", webEx);
            }
        }

        /// <summary>
        /// Gets the Graph which comprises the class hierarchy and individuals of those classes.
        /// </summary>
        /// <param name="callback">Callback to invoke when the operation completes.</param>
        /// <param name="state">State to pass to the callback.</param>
        /// <remarks>
        /// If the operation succeeds the callback will be invoked normally, if there is an error the callback will be invoked with a instance of <see cref="AsyncError"/> passed as the state which provides access to the error message and the original state passed in.
        /// </remarks>
        public void Realize(GraphCallback callback, Object state)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Endpoint.Uri);
            request.Method = Endpoint.HttpMethods.First();
            request.Accept = MimeTypesHelper.CustomHttpAcceptHeader(MimeTypes, MimeTypesHelper.SupportedRdfMimeTypes);

            try
            {
                request.BeginGetResponse(result =>
                    {
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse) request.EndGetResponse(result))
                            {
                                IRdfReader parser = MimeTypesHelper.GetParser(response.ContentType);
                                Graph g = new Graph();
                                parser.Load(g, new StreamReader(response.GetResponseStream()));

                                response.Close();
                                callback(g, state);
                            }
                        }
                        catch (WebException webEx)
                        {
                            if (webEx.Response != null)
                            {
                            }

                            callback(null, new AsyncError(new RdfReasoningException("A HTTP error occurred while communicating with the Pellet Server, see inner exception for details", webEx), state));
                        }
                        catch (Exception ex)
                        {
                            callback(null, new AsyncError(new RdfReasoningException("An unexpected error occurred while communicating with the Pellet Server, see inner exception for details", ex), state));
                        }
                    }, null);
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                }

                callback(null, new AsyncError(new RdfReasoningException("A HTTP error occurred while communicating with the Pellet Server, see inner exception for details", webEx), state));
            }
            catch (Exception ex)
            {
                callback(null, new AsyncError(new RdfReasoningException("An unexpected error occurred while communicating with the Pellet Server, see inner exception for details", ex), state));
            }
        }
    }
}
