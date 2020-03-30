using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            string name = null;
            if(request?.QueryStringParameters !=null && request.QueryStringParameters.ContainsKey("name"))
            {
                name = request.QueryStringParameters["name"];
            }

            string output = "Please provide your name";
            if (name != null)
            {
                output = "Hi how are you" + name;
            }

            return output;
        }
    }
}
