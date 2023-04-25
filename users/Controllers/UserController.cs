    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using User.Context;
    using User.Entities;
    using User.Models;

    namespace User.Controllers {

      [Route("[controller]")]
      [ApiController]
      public class UserController: ControllerBase {
        private UserContext _userContext;

        public UserContext UserContext {
          get => _userContext;
          set => _userContext = value;
        }

        public UserController(UserContext userContext) {
          UserContext = userContext;
        }

        [HttpGet]
        public IEnumerable < UserEntity > GetAsync() {
          try {
            return UserContext.Users;
          } catch (Exception) {
            throw;
          }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (UserEntity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult < UserEntity > GetAsync(int id) {

          try {
            var user = UserContext.Users.FirstOrDefault(s => s.id == id);
            if (user == null) {
              return NotFound("User not found");
            }

            return user;
          } catch (Exception) {
            throw;
          }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (UserEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult < UserEntity > PostAsync([FromBody] UserEntity value) {

          try {

            if (value.email != null) {
              var userWithEmail = UserContext.Users.FirstOrDefault(s => s.email == value.email);
              if (userWithEmail != null) {
                return BadRequest("email already exists");
              }
            }

            if (value.username != null) {
              var userWithUsername = UserContext.Users.FirstOrDefault(s => s.username == value.username);
              if (userWithUsername != null) {
                return BadRequest("username already exists");
              }
            }

            UserContext.Users.Add(value);
            UserContext.SaveChanges();
            if (value.email != null) {
              return UserContext.Users.FirstOrDefault(s => s.email == value.email);
            } else {
              return UserContext.Users.FirstOrDefault(s => s.username == value.username);
            }
          } catch (Exception) {
            throw;
          }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (UserEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult < UserEntity > PutAsync(int id, [FromBody] UserEntity value) {
          try {
            if (value == null) {
              return BadRequest("Username and email is required");
            }
            if (value.email != null) {
              var userWithSameEmail = UserContext.Users.FirstOrDefault(s => s.email == value.email);
              if (userWithSameEmail != null && id != userWithSameEmail.id) {

                return BadRequest("email already exists");
              }
            }

            if (value.username != null) {
              var userWithSameUsername = UserContext.Users.FirstOrDefault(s => s.username == value.username);
              if (userWithSameUsername != null && id != userWithSameUsername.id) {
                return BadRequest("username already exists");
              }
            }

            var user = UserContext.Users.FirstOrDefault(s => s.id == id);
            if (user == null) {
              return NotFound("user does not exist");
            }

            UserContext.Entry < UserEntity > (user).CurrentValues.SetValues(value);
            UserContext.SaveChanges();
            return UserContext.Users.FirstOrDefault(s => s.id == id);
          } catch (Exception) {
            throw;
          }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult < string > DeleteAsync(int id) {
          try {
            var user = UserContext.Users.FirstOrDefault(s => s.id == id);
            if (user == null) {
              return NotFound("User does not exist");
            }

            UserContext.Users.Remove(user);
            UserContext.SaveChanges();
            return "success";

          } catch (Exception) {
            throw;
          }
        }
      }
    }