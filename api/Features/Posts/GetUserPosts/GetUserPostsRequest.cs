﻿using Api.Features.Users;
using FastEndpoints;

namespace Api.Features.Posts.GetUserPosts
{
    public class GetUserPostsValidator : Validator<GetUserPostsRequest>
    {
        public GetUserPostsValidator()
        {
            RuleFor(r => r.UserId)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var users = Resolve<UserRepository>();
                        var userExists = await users.CheckIfExistsAsync(id);

                        return userExists;
                    }
                );
        }
    }

    public class GetUserPostsRequest
    {
        public Guid UserId { get; set; }
    }
}
