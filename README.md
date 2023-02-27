# THE Secret Santa (Wish List Application)
This is a mini application for sending, storing, displaying, and searching through wish lists for Secret Santa. The application is built using ASP.NET Core and React.

### Technologies:
- ReactJs
- RTK Qery
- Redux
- Tailwindcss
- ASP.net core
- EF Core

### Requirements for the test task
- Create a form using React with at least 5 fields of different types (drop down, text, checkbox, radio button).
- Implement validation for the fields.
- Implement a list of forms with the ability to search.
- Implement the REST service using .NET Core and C#:
- The service provides all methods for the front end.
- The service receives and stores forms without hardcoded models, imagining that the service can be accessed by different clients with a different set of fields.
- Use an in-memory database to store data.
- Pack all the JS and CSS files into one file.

## How to Run
- Clone the repository to your local machine.
- Navigate to the project folder in the command prompt or terminal.
- Run the following commands

For backend part
```sh
dotnet run
```

For frontend part
```sh
npm install
npm run start
```

### Idea
The application is designed to help users create their wish list for Secret Santa. Users can fill out a form to indicate what they would like to receive as a gift. The form includes at least 5 fields of different types (drop down, text, checkbox, radio button) to allow users to provide detailed information about their preferences.

Once a user submits their wish list, the application stores the data in an in-memory database. Other users can view all the wish lists and search for specific gifts. The application also allows users to reserve a gift to prevent multiple people from choosing the same item.

Overall, the Secret Santa Wish List Application provides an easy and efficient way for users to create and share their wish list for Secret Santa.

### Preview

![Preview logo](https://github.com/kirsan-sad/TheSecretSanta/blob/master/preview.JPG?raw=true, "Preview")