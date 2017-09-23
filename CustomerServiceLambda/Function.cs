using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CustomerServiceLambda
{
    public class Function
    {
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {

            string customerId = string.Empty;
            
            if (request.QueryStringParameters != null && request.QueryStringParameters.ContainsKey("id"))
            {
                customerId = request?.QueryStringParameters["id"];
            }

            var customer = GetCustomer(customerId);

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonConvert.SerializeObject(customer)
            };
        }

        public Customer GetCustomer(string id)
        {
            var dynamoDbClient = new AmazonDynamoDBClient();

            string tableName = "Customer";

            var request = new QueryRequest
            {
                TableName = tableName,
                KeyConditionExpression = "Id = :v_Id",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                                           {":v_Id", new AttributeValue { S =  id }}}
            };

            var response = dynamoDbClient.QueryAsync(request).Result;
            var item = response.Items.First();

            var customerName = item["CustomerName"].S;

            return new Customer { Id = id, CustomerName = customerName };
        }

    }

    public class Customer
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
    }

}
