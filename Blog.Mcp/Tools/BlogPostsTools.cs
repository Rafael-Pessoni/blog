using System.ComponentModel;
using Blog.Mcp.Helpers;
using ModelContextProtocol.Server;

namespace Blog.Mcp.Tools;

[McpServerToolType]
public static class BlogPostsTools
{
    [McpServerTool, Description("Returns a list of all blog posts in the database.")]
    public static async Task<string> GetAllBlogPosts(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync($"posts");
        if (!response.IsSuccessStatusCode)
            return $"Error: {response.StatusCode}";

        return await response.Content.ReadAsStringAsync();
    }

    [McpServerTool, Description("Returns the details including the content of a blog post.")]
    public static async Task<string> GetBlogPostDetails(HttpClient httpClient,
        [Description("Post's id to return")] string postId)
    {
        var response = await httpClient.GetAsync($"posts/{postId}");
        if (!response.IsSuccessStatusCode)
            return $"Error: {response.StatusCode}";

        return await response.Content.ReadAsStringAsync();
    }

    [McpServerTool, Description("Add a new blog post.")]
    public static async Task<string> AddBlogPost(HttpClient httpClient,
        [Description("Title of the post to include")] string title,
        [Description("Content of the post to include")] string content)
    {
        var post = new { Title = title, Content = content };
        var response = await httpClient.PostAsync("posts", post);
        if (!response.IsSuccessStatusCode)
            return $"Error: {response.StatusCode}";

        return await response.Content.ReadAsStringAsync();
    }

    [McpServerTool, Description("Add a comment to a blog post.")]
    public static async Task<string> AddComment(HttpClient httpClient,
        [Description("Id of the post")] string postId,
        [Description("Content of the comment")] string content)
    {
        var comment = new { Content = content };
        var response = await httpClient.PostAsync($"posts/{postId}/comments", comment);
        if (!response.IsSuccessStatusCode)
            return $"Error: {response.StatusCode}";

        return await response.Content.ReadAsStringAsync();
    }
}
