using DB;
using FoodCoupons.ReopositoryL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.DTOs;
using Services.SearchService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]

public class UserController : ControllerBase 
{

    private readonly DBContext _context;
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public UserController(DBContext context, IConfiguration configuration, IUserService userService)
    {
        _context = context;
        _configuration = configuration;
        _userService = userService;

    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] LoginDto model)
    {
        var user = _context.Users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var claims = new[]
        {
           new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(30);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = expires
        });













    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> SearchIds(int searchValue)
    {
        var filteredIds = await _userService.SearchIdsAsync(searchValue);
        return Ok(filteredIds);
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetQRCodeByEmployeeId()
    {
        var userId=User.Claims.FirstOrDefault(x=>x.Type=="Id")?.Value;
        if(userId == null)
        {
            return BadRequest();
        }
        var qrcode = await _userService.GetEmployeeQRCode(userId);
        return Ok(qrcode);
    }









}
