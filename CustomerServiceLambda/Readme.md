# Customer Service Lambda 

This starter project consists of:
* Function.cs - class file containing a class with a single function handler method
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS
* project.json - .NET Core project file with build and tool declarations for the Amazon.Lambda.Tools Nuget package

You may also have a test project depending on the options selected. 

The generated function handler is a simple method accepting a string argument that returns the uppercase equivalent of the input string. Replace the body of this method, and parameters, to suit your needs. 

## Detials about the function:

This simple Lambda function returns the customer details from the DynamoDB.

This Lambda funtion will be triggered by the AWS API Gateway. 

See the following Blog:
https://www.irfanm.com/2017/09/23/create-the-serverless-microservice-with-aws-lambda-and-api-gateway-in-net-core

