# Azure Functions Custom Bindings for Slack

## Prerequisites: Slack settings

- Setup **Incoming Webhook** and get webhook url. See [Slack official document](hhttps://api.slack.com/messaging/webhooks).  
  or [my blog post(Japanese)](https://blog.beachside.dev/entry/2020/01/30/223000)

## Prerequisites: Functions App settings

Functions App use environment valiable "Slack:IncomingWebhookUrl", so need to set it.

### For local debug

- add `local.settings.json` file.
- add following json

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "Slack:IncomingWebhookUrl": "<slack webhook url !!!! >"
  }
}
```

(This may not be used depending on usage. Usage describe "How to use" section.)

### For Running on Azure

- Set "Slack:IncomingWebhookUrl" key and value to Application settings.

(This may not be used depending on usage. Usage describe "How to use" section.)

## How to use

There are two ways to get Slack-IncomingWebhookUrl.

- Pattern1: Set Slack-IncomingWebhookUrl to environment valiable and get from it.
- Pattern2: get lack-IncomingWebhookUrl from Function method input.

In [SandboxFunctionApp](./sandbox/SandboxFunctionApp),  
Function1 and Function2 is Pattern1.  
Function3 is Pattern2.

Pattern1 and Pattern2 cannot coexist in same function instance because of Attribute and Collector Dependency.  
Please refer to sample code for usage: [SandboxFunctionApp](./sandbox/SandboxFunctionApp).


## How to Create BlockKit Message

[BlockKit](https://api.slack.com/block-kit) provided by Slack is UI framework for Slack apps .

In [WebJobsExtensions.CustomBindings.Slack](./src/WebJobsExtensions.CustomBindings.Slack) project, I implemented C# Extension-Methods for my minimun requirement in `BlockKit` directory and use `SlackMessageHelper.cs`.

You can try to build the BlockKit fromat : <https://api.slack.com/tools/block-kit-builder>


## More Information: My blog posts

- [Setup Incoming Webhook on Slack](https://blog.beachside.dev/entry/2020/01/30/223000)
- [How to create Custom Bindings for Slack](https://blog.beachside.dev/entry/2020/02/05/200000)



## 個人用メモ: Azure Artifacts feed

Azure DevOps > beachside > nuget-feed project にて public feed を利用中。
