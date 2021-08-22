using Microsoft.AspNetCore.Authorization;

namespace Grader.Api.Policies
{
    public static class PolicyConfig
    {
        public static void DefinePolicies(this AuthorizationOptions options)
        {
            options.AddPolicy(PolicyNames.ADMIN, policy => policy.RequireRole("admin"));

        }
    }
}
