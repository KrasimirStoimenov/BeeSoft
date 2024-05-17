namespace BeeSoft.Web.Infrastructure.Extensions;

using BeeSoft.Web.Infrastructure.Extensions.Models;

using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public static class EndpointConventionBuilderExtensions
{
    public static IEndpointConventionBuilder MapCustomIdentityApi<TUser>(this IEndpointRouteBuilder endpoints)
    where TUser : class, new()
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var routeGroup = endpoints.MapGroup("");

        routeGroup.MapPost("/login", async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>>
            ([FromBody] LoginRequestModel login, [FromServices] IServiceProvider sp) =>
        {
            var signInManager = sp.GetRequiredService<SignInManager<TUser>>();

            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

            var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
            }

            // The signInManager already produced the needed response in the form of a cookie or bearer token.
            return TypedResults.Empty;
        });

        return new IdentityEndpointsConventionBuilder(routeGroup);
    }


    // Wrap RouteGroupBuilder with a non-public type to avoid a potential future behavioral breaking change.
    private sealed class IdentityEndpointsConventionBuilder(RouteGroupBuilder inner) : IEndpointConventionBuilder
    {
        private IEndpointConventionBuilder InnerAsConventionBuilder => inner;

        public void Add(Action<EndpointBuilder> convention) => InnerAsConventionBuilder.Add(convention);
        public void Finally(Action<EndpointBuilder> finallyConvention) => InnerAsConventionBuilder.Finally(finallyConvention);
    }

}
