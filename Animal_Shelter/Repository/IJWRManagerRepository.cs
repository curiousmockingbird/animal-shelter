using Animal_Shelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Shelter.Repository
{
public interface IJWTManagerRepository
{
  Tokens Authenticate(Users users); 
}

}