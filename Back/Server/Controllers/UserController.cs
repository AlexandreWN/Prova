using Microsoft.AspNetCore.Mvc;
using Model;
using Microsoft.EntityFrameworkCore;
namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object? resgisterUser([FromBody] User user)
    {
        var id = user.save();
        if(id == -1){
            return "usuario ja cadastrado";
        }
        else{
            return new {
                id = id,
                nome = user.nome,
                idade = user.idade,
                raca = user.raca,
                login = user.login,
                password = user.password,
                foto = user.foto,
            };
        }
    }

    [HttpPost]
    [Route("login")]
    public Object loginUser([FromBody] User user){
        if(user != null && user.login != null && user.password != null){
            var userLogin = Model.User.loginUser(user.login,user.password);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (userLogin != null) {
                return new
                {
                    id = userLogin.id,
                    login = userLogin.login,
                    password = userLogin.password
                };
            }
            else{
                return 0;
            }
        }
        else{
            return 0;
        }
    }
}
