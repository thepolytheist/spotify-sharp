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
            return Get<Artist>(new Uri(BaseUri, id));
        }

        public async Task<IList<Artist>> Get(IEnumerable<string> ids)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("ids", string.Join(",", ids));

            return (await Get<ArtistsResponse<IList<Artist>>>(BaseUri, queryParams)).Artists;
        }

        public Task<PagingObject<AlbumSimplified>> GetAlbums(Artist artist)
        {
            return GetAlbums(artist.Id);
        }

        public Task<PagingObject<AlbumSimplified>> GetAlbums(string id)
        {
            return Get<PagingObject<AlbumSimplified>>(new Uri(BaseUri, $"{id}/albums"));
        }

        public Task<IList<Track>> GetTopTracks(Artist artist, string country)
        {
            return GetTopTracks(artist.Id, country);
        }

        public async Task<IList<Track>> GetTopTracks(string id, string country)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("country", country);

            return (await Get<TracksResponse<IList<Track>>>(new Uri(BaseUri, $"{id}/top-tracks"), queryParams)).Tracks;
        }

        public Task<IList<Artist>> GetRelatedArtists(Artist artist)
        {
            return GetRelatedArtists(artist.Id);
        }

        public async Task<IList<Artist>> GetRelatedArtists(string id)
        {
            return (await Get<ArtistsResponse<IList<Artist>>>(new Uri(BaseUri, $"{id}/related-artists"))).Artists;
        }
    }
}