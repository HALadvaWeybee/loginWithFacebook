using AngularAndNetCoreAuth.Data;
using AngularAndNetCoreAuth.Models;
using AngularAndNetCoreAuth.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AngularAndNetCoreAuth.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("EnableCors")]
    public class AccountController : Controller
    {
        private readonly UsersDbContext _db;
        private readonly IAuthService AuthService;


        public AccountController(UsersDbContext db, IAuthService authService)
        {
            _db = db;
            AuthService = authService;
        }

        /// <summary>
        /// This method just takes the data from our client side, that our angular-social-login provides for us, then it takes some part of that data and creates a token 
        /// that is sent back to the user. On every request, you should add to token to the request headers so the user can be authourized on every request.
        /// </summary>
        /// <param name="userdata"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FacebookLogin")]
        public async Task<IActionResult> FacebookLogin([FromBody] TokenModel accessToken)
        {
            var fbval = await AuthService.FacebookLogin(accessToken);
            if (fbval.Success)
            {                                                                     
                return Ok(fbval);
            }
            else
            {
                return new BadRequestObjectResult(fbval);
            }
        }

        //[HttpPost("[action]")]
        /*public async Task<IActionResult> Login([FromBody] LoginViewModel userdata)
        {

            if (userdata != null)
            {
                //Checks if the user has been saved before. It won't make sense to save twice.
                var alreadySavedData = _db.UserData.Where(Uid => Uid.UserId == userdata.UserId).FirstOrDefault();


                if (ModelState.IsValid)
                {

                    //Take some part of the data and create a JWT token using Asp.Net Core's JWT Authentication.
                    //PS: We already defined some of this in our startup class
                    var claims = new[]
                  {
                        new Claim(JwtRegisteredClaimNames.Sub, userdata.FirstName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userdata.UserId )
                    };

                    var loginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                    var token = new JwtSecurityToken(
                        issuer: "ifeoluwa",
                        audience: "ifeoluwa",
                        expires: DateTime.UtcNow.AddYears(1),
                        claims: claims,
                        signingCredentials: new SigningCredentials(loginKey, SecurityAlgorithms.HmacSha256)
                        );

                    if (alreadySavedData != null)
                    {
                        //Return user details alongside token.
                        return Ok(new
                        {
                            id = alreadySavedData.Id,
                            message = "User data has already been saved",
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            username = alreadySavedData.FirstName,
                            pictureUrl = alreadySavedData.PictureUrl,
                            userRole = "user",
                        });
                    }

                    //Creates new user record in DB.
                    var user = new UserData
                    {
                        UserId = userdata.UserId,
                        FirstName = userdata.FirstName,
                        LastName = userdata.LastName,
                        PictureUrl = userdata.PictureUrl,
                        EmailAddress = userdata.EmailAddress,
                        Provider = userdata.Provider
                    };



                    await _db.AddAsync(user);

                    await _db.SaveChangesAsync();


                    //Return user details alongside token.
                    //return Ok(new
                    //{
                    //    id = user.Id,
                    //    message = "User Login successful",
                    //    username = user.FirstName,
                    //    pictureUrl = user.PictureUrl,
                    //    userRole = "user",
                    //    token = new JwtSecurityTokenHandler().WriteToken(token),
                    //    expiration = token.ValidTo
                    //});
                    return Ok(new AuthenticationProperties { RedirectUri = "/" });
                    //return StatusCode(StatusCodes.Status301MovedPermanently);

                }
            }


            var errors = ModelState.Values.First().Errors;
            System.Console.WriteLine("Hello Himanshu");

            return BadRequest(new JsonResult(errors));



        }*/
        public IActionResult Index()
        {
            return Ok();
        }

    }
}

