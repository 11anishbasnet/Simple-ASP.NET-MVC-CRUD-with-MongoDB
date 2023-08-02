using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDb.Models.Repo;
using MongoDb.Models;
using System.Collections.Generic;

namespace MongoDb.Controllers
{


    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(string id)
        {
            List<User> users = _userRepository.GetAllUsers();
            ViewData["Users"] = users;
            if (id!= null)
            {
                // Edit scenario: Retrieve the user by ID and pass it to the view
                User user = _userRepository.GetUserById(id);

                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Index(User updatedUser)
        {


            if ( updatedUser.Id!= null)
            {
                _userRepository.UpdateUser(updatedUser);
                List<User> users = _userRepository.GetAllUsers();
                ViewData["Users"] = users;
                return RedirectToAction(nameof(Index));
            }
            else
            {

                _userRepository.AddUser(updatedUser);
                List<User> users = _userRepository.GetAllUsers();
                ViewData["Users"] = users;
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
