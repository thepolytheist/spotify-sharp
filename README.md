# SpotifySharp
A basic .NET wrapper over the Spotify v1 REST API.

> PLEASE READ: This guide is being written before full implementation and refactoring. It is subject to becoming obsolete at any given time.

## Using the Client
### Authenticating
To try out the CLI and get a basic feel for the API structure, you'll first need to generate a client ID and secret at the [developer portal](https://developer.spotify.com/dashboard/). You can paste these keys in relevant spot at the top of the CLI's `Program.cs`. From here, the CLI will request an access key from the auth API and set the default header for your SpotifySharp API client.

### Retrieving Data
From here it's up to you. Most calls will be of the format 
```
client.<Repository>.Get(<id>);
```
where `<Repository>` is one of the client repositories like `Albums`, `Artists`, etc.

## Helping Out
See the [contribution guide](https://github.com/thepolytheist/spotify-sharp/blob/master/CONTRIBUTING.md) for more info.