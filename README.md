# Cryptic Push Notification Service

This project contains a gRPC microservice that sends push notifications using Firebase Cloud Messaging (FCM). Another application can interact with this service over gRPC and expose REST endpoints if needed.

## Configuration

1. Create a Firebase service account and download the credentials JSON file.
2. Place the file next to the service (or provide the path) and set the `Firebase:CredentialsPath` value in `appsettings.json` or as an environment variable.

## Running

```bash
# Build and run the service
# Requires .NET 8 SDK
cd CrypticPushNotificationService
 dotnet run
```

The service exposes gRPC endpoints defined in `Protos/push.proto`.
