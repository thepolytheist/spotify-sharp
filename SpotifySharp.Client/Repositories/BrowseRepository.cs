using SpotifySharp.Client.Responses;
using SpotifySharp.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifySharp.Client.Repositories
{
    public class BrowseRepository : BaseRepository
    {
        public static readonly string DEFAULT_ENDPOINT = "browse/";
        
        public BrowseRepository(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress) { }

        public BrowseRepository(HttpClient httpClient, Uri baseUri) : base(httpClient, baseUri) { }

        public Task<Category> GetCategory(string id)
        {
            return Get<Category>(new Uri(BaseUri, $"categories/{id}"));
        }

        public async Task<PagingObject<PlaylistSimplified>> GetCategoryPlaylists(string id)
        {
            return (await Get<PlaylistsResponse<PagingObject<PlaylistSimplified>>>(new Uri(BaseUri, $"categories/{id}/playlists"))).Playlists;
        }

        public async Task<PagingObject<Category>> GetCategories()
        {
            return (await Get<CategoriesResponse<PagingObject<Category>>>(new Uri(BaseUri, "categories"))).Categories;
        }

        public async Task<PagingObject<PlaylistSimplified>> GetFeaturedPlaylists()
        {
            return (await Get<PlaylistsResponse<PagingObject<PlaylistSimplified>>>(new Uri(BaseUri, "featured-playlists"))).Playlists;
        }

        public async Task<PagingObject<AlbumSimplified>> GetNewReleases()
        {
            return (await Get<AlbumsResponse<PagingObject<AlbumSimplified>>>(new Uri(BaseUri, "new-releases"))).Albums;
        }
    }
}