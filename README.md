# _Animal Shelter API_

#### By _**Harold Mesa**_

#### _API for a shelter of dogs and cats._

## Technologies Used

* _C#_
* _.NET Core_
* _MySQL_
* _Entity_
* _Json Web Token (JWT) for token-based authentication._

## Description

_The Animal Shelter API provides with a database of dogs and cats. It is an API that uses the Jason Web Token (JWT) technique. Data sent between two parties using JWT is digitally signed and can be easily confirmed and trusted._

_All requests are made to endpoints beginning: http://localhost:5004/api/_

_The API has three endpoints:_
* _api/users_
* _api/cats_
* _api/dogs_

_api/cats and api/dogs provide with a database of cats and dogs, respectively. You can filter the search for cats or dogs in the database based on two parameters, their name or their sex, in the following way:_
* _api/cats?name='The name of the cat you want to look for'_
* _api/cats?sex=male_
* _api/cats?sex=female_

_Though at the moment anyone with a token can have access to the information of the users of the API (which is an inconvenient situation), keep in mind that the api/users endpoint was thought to be accessed only by administrators of the API. It is out of the scope of this project to assign user roles for the site._

_In order to access the database, you will need an generate a Jason Web token and submit it with your API requests. An Jason Web token grants limited access to a user’s account. These are the steps to generate and use a JWT in the API:_

## Setup/Installation Requirements

##### _Requesting an access token:_

* _Clone this repository to your desktop_
* _Navigate to Animal_Shelter/_
* _At the Animal_Shelter folder, create a file called appsettings.json. Paste the following code and create a password in the "Key" property of the JWT field:_
 _{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid=root;pwd=["YOUR-MYSQL-PASSWORD"];"
  },
  "JWT": {
    "Key": "Your super secret key goes here",
    "Issuer": "https://animal_shelter.info",
    "Audience": "Animal_Shelter.com"
  }
}_

* _If you haven't yet, install the dotnet ef tool through your command line (run $ dotnet tool install --global dotnet-ef --version 5.0.1)_
* _Run $ dotnet ef database update_
* _Run $ dotnet watch run to run the API. It will open the http://localhost:5004/api/users endpoint. Open this URL in POSTMAN and send request_
* _You will get an "401 Unauthorized" response. 
<img src="img/Screenshot 2022-10-29 at 07.47.02.png">_
* _To authenticate, go to http://localhost:5004/api/users/authenticate, open the Body tab in POSTMAN, input one of the three current users of the API, and their password. You should make a POST request to authenticate the user. 
<img src="img/Screenshot 2022-10-29 at 08.01.33.png">_
* _It will generate your Jason Web Token. 
<img src="img/Screenshot 2022-10-29 at 08.03.02.png">_   

##### _Using your access token:_

* _You will use your token in order to access the API endpoints. In POSTMAN, go to the Authorization tab, select the "Bearer Token" option, and place your token. Now you may access any of the API endpoints. 
<img src="img/Screenshot 2022-10-29 at 08.14.47.png">_

##### _Post, Put and Delete functionality:_
###### _Post:_
* _Once the user is authenticated, you can create/add a dog or cat to the database. Go to the Body tab, select raw and JSON as the file extension, and input the four properties of the dog or cat(catId/dogId, name, age, sex). Make sure you make a POST request to the api/cats or api/dogs endpoint, depending on the animal you want to add/create:_

<img src="img/Screenshot 2022-11-04 at 12.50.png">          

* _You will get a "201 Created" message._

* _When you make another GET request, you'll see a new cat/dog will be added to the database:_

<img src="img/Screenshot 2022-11-04 at 12.53.png">

###### _Put:_

* _In order to modify any properties of a cat or dog, go to the Body tab, select raw and JSON as the file extension, and modify property/properties of the dog or cat(catId/dogId, name, age, sex). Make sure you make a PUT request to the api/cats or api/dogs endpoint —depending on the animal you are modifying—, followed by the id number of the animal:_

<img src="img/put/Screenshot 2022-11-04 at 13.33.png">

* _You wil get a "204 No Content" error message._

<img src="img/put/Screenshot 2022-11-04 at 13.35.58.png">

* _However, if you make another GET request to your api/cats or api/dogs endpoint, you will see the modified property/properties:_

<img src="img/put/Screenshot 2022-11-04 at 13.39.28.png">

###### _Delete:_

* _In order to delete an animal from the database, make sure you make a DELETE request to the api/cats or api/dogs endpoint —depending on the animal—, followed by the id number of the animal you want to remove from the database:_

<img src="img/put/Screenshot 2022-11-04 at 13.45.34.png">

* _You wil get a "204 No Content" error message:_

<img src="img/put/Screenshot 2022-11-04 at 13.45.44.png">

* _If you make another GET request, you will see the animal was removed from the database:_

<img src="img/put/Screenshot 2022-11-04 at 13.46.23.png">

## Known Bugs

* _No known bugs_

## License

_[MIT License](https://en.wikipedia.org/wiki/MIT_License)_

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Copyright (c) _29 Oct, 2022_ _Harold Mesa_
