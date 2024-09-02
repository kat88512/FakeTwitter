﻿using System.IdentityModel.Tokens.Jwt;
using Api.Features.Users;
using FastEndpoints;

namespace Api.Features.Follows.FollowUser
{
    public class FollowUserValidator : Validator<FollowUserRequest>
    {
        public FollowUserValidator()
        {
            RuleFor(r => r.UserId).NotEqual(r => r.TargetUserId);

            RuleFor(r => r.TargetUserId)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var users = Resolve<UserRepository>();
                        var userExists = await users.CheckIfExistsAsync(id);

                        return userExists;
                    }
                );

            RuleFor(r => new { r.UserId, r.TargetUserId })
                .MustAsync(
                    async (followId, ct) =>
                    {
                        var follows = Resolve<FollowRepository>();

                        var followExists = await follows.CheckIfExistsAsync(
                            (followId.UserId, followId.TargetUserId)
                        );

                        return !followExists;
                    }
                );
        }
    }

    public class FollowUserRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
