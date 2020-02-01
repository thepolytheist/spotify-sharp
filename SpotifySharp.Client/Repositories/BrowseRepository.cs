using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifySharp.Client.Responses;
using SpotifySharp.Model;

namespace SpotifySharp.Client.Repositories
{
    public class BrowseRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "browse/";
        
        public BrowseRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public BrowseRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public async Task<Category> GetCategory(string id)
        {
            return await Get<Category>(new Uri(this.BaseUri, $"categories/{id}"));
        }

        public async Task<PagingObject<PlaylistSimplified>> GetCategoryPlaylists(string id)
        {
            return (await Get<PlaylistsResponse<PagingObject<PlaylistSimplified>>>(new Uri(this.BaseUri, $"categories/{id}/playlists"))).Playlists;
        }

        public async Task<PagingObject<Category>> GetCategories()
        {
            return (await Get<CategoriesResponse<PagingObject<Category>>>(new Uri(this.BaseUri, "categories"))).Categories;
        }

        public async Task<PagingObject<PlaylistSimplified>> GetFeaturedPlaylists()
        {
            return (await Get<PlaylistsResponse<PagingObject<PlaylistSimplified>>>(new Uri(this.BaseUri, "featured-playlists"))).Playlists;
        }

        public async Task<PagingObject<AlbumSimplified>> GetNewReleases()
        {
            return (await Get<AlbumsResponse<PagingObject<AlbumSimplified>>>(new Uri(this.BaseUri, "new-releases"))).Albums;
        }
    }
}