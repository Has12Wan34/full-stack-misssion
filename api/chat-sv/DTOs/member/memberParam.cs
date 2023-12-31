using Microsoft.AspNetCore.Mvc;

namespace TodoApi.DTOs
{
    public class MemberParam 
    {
        [FromRoute(Name="id")]
        public int? MemberId {get; set;}

        [FromQuery(Name="name")]
        public string? Name {get; set;}
    }
}