using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifySharp.Client.Responses;
using SpotifySharp.Model;

namespace SpotifySharp.Client.Repositories
{
    public class ArtistRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "artists/";
        
        public ArtistRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public ArtistRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public async Task<Artist> Get(string id)
        {
            return await Get<Artist>(new Uri(this.BaseUri, id));
        }

        public async Task<List<Artist>> Get(string[] ids)
        {
            return (await Get<ArtistsResponse<List<Artist>>>(new Uri(this.BaseUri, $"?ids={string.Join(",", ids)}"))).Artists;
        }

        public async Task<PagingObject<AlbumSimplified>> GetAlbums(Artist artist)
        {
            return await GetAlbums(artist.Id);
        }

        public async Task<PagingObject<AlbumSimplified>> GetAlbums(string id)
        {
            return await Get<PagingObject<AlbumSimplified>>(new Uri(this.BaseUri, $"{id}/albums"));
        }

        public async Task<List<Track>> GetTopTracks(Artist artist, string country)
        {
            return await GetTopTracks(artist.Id, country);
        }

        public async Task<List<Track>> GetTopTracks(string id, string country)
        {
            return (await Get<TracksResponse<List<Track>>>(new Uri(this.BaseUri, $"{id}/top-tracks?country={country}"))).Tracks;
        }

        public async Task<List<Artist>> GetRelatedArtists(Artist artist)
        {
            return await GetRelatedArtists(artist.Id);
        }

        public async Task<List<Artist>> GetRelatedArtists(string id)
        {
            return (await Get<ArtistsResponse<List<Artist>>>(new Uri(this.BaseUri, $"{id}/related-artists"))).Artists;
        }
    }
}