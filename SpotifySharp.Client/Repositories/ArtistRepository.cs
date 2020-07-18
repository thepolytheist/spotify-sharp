using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class ArtistRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "artists/";
        
        public ArtistRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public ArtistRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<Artist> Get(string id)
        {
            return Get<Artist>(new Uri(this.BaseUri, id));
        }

        public async Task<List<Artist>> Get(string[] ids)
        {
            return (await Get<ArtistsResponse<List<Artist>>>(new Uri(BaseUri, $"?ids={string.Join(",", ids)}"))).Artists;
        }

        public Task<PagingObject<AlbumSimplified>> GetAlbums(Artist artist)
        {
            return GetAlbums(artist.Id);
        }

        public Task<PagingObject<AlbumSimplified>> GetAlbums(string id)
        {
            return Get<PagingObject<AlbumSimplified>>(new Uri(BaseUri, $"{id}/albums"));
        }

        public Task<List<Track>> GetTopTracks(Artist artist, string country)
        {
            return GetTopTracks(artist.Id, country);
        }

        public async Task<List<Track>> GetTopTracks(string id, string country)
        {
            return (await Get<TracksResponse<List<Track>>>(new Uri(BaseUri, $"{id}/top-tracks?country={country}"))).Tracks;
        }

        public Task<List<Artist>> GetRelatedArtists(Artist artist)
        {
            return GetRelatedArtists(artist.Id);
        }

        public async Task<List<Artist>> GetRelatedArtists(string id)
        {
            return (await Get<ArtistsResponse<List<Artist>>>(new Uri(BaseUri, $"{id}/related-artists"))).Artists;
        }
    }
}