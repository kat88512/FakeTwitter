﻿using api.Models;
using FastEndpoints;

namespace api.Features.Posts.AddPost
{
    public class AddPostValidator : Validator<AddPostRequest>
    {
        public AddPostValidator()
        {
            RuleFor(p => p.Text).NotEmpty().MaximumLength(Post.TextMaxLength);

            RuleFor(p => p.Id)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var posts = Resolve<IPostRepository>();
                        var exists = await posts.CheckIfExistsAsync(id);

                        return !exists;
                    }
                );
        }
    }

    public class AddPostRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
